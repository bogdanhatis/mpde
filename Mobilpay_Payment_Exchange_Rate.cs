// Decompiled with JetBrains decompiler
// Type: MobilpayEncryptDecrypt.Mobilpay_Payment_Exchange_Rate
// Assembly: MobilpayEncryptDecrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E9668A4E-41EC-4174-9AFB-E80FB974BD68
// Assembly location: C:\Users\bogdan.hatis\Desktop\WebSite1\MobilpayEncryptDecrypt.dll

using System;
using System.Xml.Serialization;

namespace MobilpayEncryptDecrypt
{
  [Serializable]
  public class Mobilpay_Payment_Exchange_Rate
  {
    private string currency;
    private Decimal rate;

    [XmlText]
    public Decimal Rate
    {
      get
      {
        return this.rate;
      }
      set
      {
        this.rate = value;
      }
    }

    [XmlAttribute("curency")]
    public string Currency
    {
      get
      {
        return this.currency;
      }
      set
      {
        this.currency = value;
      }
    }
  }
}
