using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace DigitalSignature
{
    public partial class DigitalSignatureForm : Form
    {
        private List<X509Certificate2> Certificates;
        private List<DigitalSignature> DigitalSignatures;

        public DigitalSignatureForm()
        {
            Certificates = new List<X509Certificate2>();
            DigitalSignatures = new List<DigitalSignature>();
            
            InitializeComponent();
            InitializeAvailableCerts();
        }
        
        private void InitializeAvailableCerts()
        {
            try
            {
                X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);

                X509Certificate2Collection validCerts = store.Certificates.Find(X509FindType.FindByTimeValid, DateTime.Now, false);

                if (validCerts.Count == 0)
                {
                    lbxAvailableCerts.Items.Add("Trenutno nemate validnih sertifikata");
                    lbxAvailableCerts.Enabled = false;
                }

                foreach (var cert in validCerts)
                {
                    var certInfo = "Ime: " + cert.GetNameInfo(X509NameType.SimpleName, false);
                    certInfo += ", Važi od: " + cert.NotBefore.Date.ToString("dd.MM.yyyy.");
                    certInfo += ", Važi do: " + cert.NotAfter.Date.ToString("dd.MM.yyyy.");

                    lbxAvailableCerts.Items.Add(certInfo);
                    Certificates.Add(cert);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUploadDocument_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    lblChosenDocument.Text = openFileDialog.SafeFileName;
                }

                if (string.IsNullOrEmpty(openFileDialog.FileName))
                {
                    lblChosenDocument.Text = "Trenutno nemate izabrani dokument";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSignDocument_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedIndexCert = lbxAvailableCerts.SelectedIndex;
                if (selectedIndexCert == -1)
                {
                    MessageBox.Show("Morate izabrati sertifikat.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (string.IsNullOrEmpty(openFileDialog.FileName))
                {
                    MessageBox.Show("Morate ucitati dokument.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var certificate = Certificates[selectedIndexCert];
                RSA privateKey = certificate.GetRSAPrivateKey();

                var documentBytes = File.ReadAllBytes(openFileDialog.FileName);
                var hashBytes = GetDataHash(documentBytes);

                var signature = privateKey.SignHash(hashBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                var digitalSignatue = new DigitalSignature
                {
                    HashDocument = Convert.ToBase64String(hashBytes),
                    Signature = Convert.ToBase64String(signature),
                    CertificateThumbprint = certificate.Thumbprint
                };
                DigitalSignatures.Add(digitalSignatue);

                MessageBox.Show("Dokument je uspešno potpisan.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerifySignature_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedIndexCert = lbxAvailableCerts.SelectedIndex;
                if (selectedIndexCert == -1)
                {
                    MessageBox.Show("Morate izabrati sertifikat.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (string.IsNullOrEmpty(openFileDialog.FileName))
                {
                    MessageBox.Show("Morate izabrati dokument.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var certificate = Certificates[selectedIndexCert];
                RSA publicKey = certificate.GetRSAPublicKey();

                var documentBytes = File.ReadAllBytes(openFileDialog.FileName);
                var hashBytes = GetDataHash(documentBytes);
                var hashString = Convert.ToBase64String(hashBytes);

                var digitalSignature = DigitalSignatures.FirstOrDefault(x => x.HashDocument == hashString && x.CertificateThumbprint == certificate.Thumbprint);
                if (digitalSignature == null)
                {
                    MessageBox.Show("Dokument nije potpisao izabrani korisnik.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var signatureBytes = Convert.FromBase64String(digitalSignature.Signature);
                bool signatureValid = publicKey.VerifyHash(hashBytes, signatureBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                if (signatureValid)
                {
                    //Ovde dodati ko ga je potpisao.
                    MessageBox.Show("Digitalni potpis je validan. Dokument nije menjan.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Digitalni potpis nije validan. Dokument je možda izmenjen.", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] GetDataHash(byte[] data)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(data);
            }
        }
    }
}