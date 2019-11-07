// Decompiled with JetBrains decompiler
// Type: JavaScience.Win32
// Assembly: MobilpayEncryptDecrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E9668A4E-41EC-4174-9AFB-E80FB974BD68
// Assembly location: C:\Users\bogdan.hatis\Desktop\WebSite1\MobilpayEncryptDecrypt.dll

using System;
using System.Runtime.InteropServices;

namespace JavaScience
{
  public class Win32
  {
    [DllImport("crypt32.dll", SetLastError = true)]
    public static extern IntPtr CertCreateSelfSignCertificate(
      IntPtr hProv,
      ref CERT_NAME_BLOB pSubjectIssuerBlob,
      uint dwFlagsm,
      ref CRYPT_KEY_PROV_INFO pKeyProvInfo,
      IntPtr pSignatureAlgorithm,
      IntPtr pStartTime,
      IntPtr pEndTime,
      IntPtr other);

    [DllImport("crypt32.dll", SetLastError = true)]
    public static extern bool CertStrToName(
      uint dwCertEncodingType,
      string pszX500,
      uint dwStrType,
      IntPtr pvReserved,
      [In, Out] byte[] pbEncoded,
      ref uint pcbEncoded,
      IntPtr other);

    [DllImport("crypt32.dll", SetLastError = true)]
    public static extern bool CertFreeCertificateContext(IntPtr hCertStore);
  }
}
