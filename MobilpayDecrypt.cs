// Decompiled with JetBrains decompiler
// Type: MobilpayEncryptDecrypt.MobilpayDecrypt
// Assembly: MobilpayEncryptDecrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E9668A4E-41EC-4174-9AFB-E80FB974BD68
// Assembly location: C:\Users\bogdan.hatis\Desktop\WebSite1\MobilpayEncryptDecrypt.dll

namespace MobilpayEncryptDecrypt
{
  public class MobilpayDecrypt
  {
    private string x509CertificateFilePath;
    private string data;
    private string decryptedData;
    private string envelopeKey;
    private string privateKeyFilePath;
    private string privateKeyPassword;

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

    public string DecryptedData
    {
      get
      {
        return this.decryptedData;
      }
      set
      {
        this.decryptedData = value;
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

    public string PrivateKeyFilePath
    {
      get
      {
        return this.privateKeyFilePath;
      }
      set
      {
        this.privateKeyFilePath = value;
      }
    }

    public string PrivateKeyPassword
    {
      get
      {
        return this.privateKeyPassword;
      }
      set
      {
        this.privateKeyPassword = value;
      }
    }
  }
}
