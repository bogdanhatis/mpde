// Decompiled with JetBrains decompiler
// Type: MobilpayEncryptDecrypt.Mobilpay_Payment_Split_Destination
// Assembly: MobilpayEncryptDecrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E9668A4E-41EC-4174-9AFB-E80FB974BD68
// Assembly location: C:\Users\bogdan.hatis\Desktop\WebSite1\MobilpayEncryptDecrypt.dll

using System;
using System.Xml.Serialization;

namespace MobilpayEncryptDecrypt
{
  [Serializable]
  public class Mobilpay_Payment_Split_Destination
  {
    private string id;
    private Decimal amount;

    [XmlAttribute("id")]
    public string Id
    {
      get
      {
        return this.id;
      }
      set
      {
        this.id = value;
      }
    }

    [XmlAttribute("amount")]
    public Decimal Amount
    {
      get
      {
        return this.amount;
      }
      set
      {
        this.amount = value;
      }
    }
  }
}
