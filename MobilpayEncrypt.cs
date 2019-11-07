// Decompiled with JetBrains decompiler
// Type: MobilpayEncryptDecrypt.MobilpayEncrypt
// Assembly: MobilpayEncryptDecrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E9668A4E-41EC-4174-9AFB-E80FB974BD68
// Assembly location: C:\Users\bogdan.hatis\Desktop\WebSite1\MobilpayEncryptDecrypt.dll

namespace MobilpayEncryptDecrypt
{
  public class MobilpayEncrypt
  {
    private string x509CertificateFilePath;
    private string data;
    private string encryptedData;
    private string envelopeKey;

    public string X509CertificateFilePath
    {
      get
      {
        return this.x509CertificateFilePath;
      }
      set
      {
        this.x509CertificateFilePath = value;
      }
    }

    public string Data
    {
      get
      {
        return this.data;
      }
      set
      {
        this.data = value;
      }
    }

    public string EncryptedData
    {
      get
      {
        return this.encryptedData;
      }
      set
      {
        this.encryptedData = value;
      }
    }

    public string EnvelopeKey
    {
      get
      {
        return this.envelopeKey;
      }
      set
      {
        this.envelopeKey = value;
      }
    }
  }
}
