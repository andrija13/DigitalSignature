﻿using System;

namespace DigitalSignature
{
    public class DigitalSignature
    {
        public string CertificateThumbprint { get; set; }

        public string HashDocument { get; set; }

        public string Signature { get; set; }
    }
}
