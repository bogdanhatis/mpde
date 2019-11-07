// Decompiled with JetBrains decompiler
// Type: MobilpayEncryptDecrypt.Mobilpay_Payment_Request_Sms
// Assembly: MobilpayEncryptDecrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E9668A4E-41EC-4174-9AFB-E80FB974BD68
// Assembly location: C:\Users\bogdan.hatis\Desktop\WebSite1\MobilpayEncryptDecrypt.dll

using System;
using System.Xml.Serialization;

namespace MobilpayEncryptDecrypt
{
  [XmlRoot("order")]
  [Serializable]
  public class Mobilpay_Payment_Request_Sms : Mobilpay_Payment_Request_Abstract
  {
    private string msisdn;
    private Mobilpay_Payment_Invoice invoice;

    public string Msisdn
    {
      get
      {
        return this.msisdn;
      }
      set
      {
        this.msisdn = value;
      }
    }

    [XmlElement("invoice")]
    public Mobilpay_Payment_Invoice Invoice
    {
      get
      {
        return this.invoice;
      }
      set
      {
        this.invoice = value;
      }
    }
  }
}
