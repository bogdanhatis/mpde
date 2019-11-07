// Decompiled with JetBrains decompiler
// Type: MobilpayEncryptDecrypt.Mobilpay_Payment_Request_Contact_Info
// Assembly: MobilpayEncryptDecrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E9668A4E-41EC-4174-9AFB-E80FB974BD68
// Assembly location: C:\Users\bogdan.hatis\Desktop\WebSite1\MobilpayEncryptDecrypt.dll

using System;
using System.Xml.Serialization;

namespace MobilpayEncryptDecrypt
{
  [Serializable]
  public class Mobilpay_Payment_Request_Contact_Info
  {
    private Mobilpay_Payment_Address billing;
    private Mobilpay_Payment_Address shipping;

    [XmlElement("billing")]
    public Mobilpay_Payment_Address Billing
    {
      get
      {
        return this.billing;
      }
      set
      {
        this.billing = value;
      }
    }

    [XmlElement("shipping")]
    public Mobilpay_Payment_Address Shipping
    {
      get
      {
        return this.shipping;
      }
      set
      {
        this.shipping = value;
      }
    }
  }
}
