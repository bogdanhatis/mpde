// Decompiled with JetBrains decompiler
// Type: MobilpayEncryptDecrypt.Mobilpay_IssueInvoice
// Assembly: MobilpayEncryptDecrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E9668A4E-41EC-4174-9AFB-E80FB974BD68
// Assembly location: C:\Users\bogdan.hatis\Desktop\WebSite1\MobilpayEncryptDecrypt.dll

using System;
using System.Xml.Serialization;

namespace MobilpayEncryptDecrypt
{
  [Serializable]
  public class Mobilpay_IssueInvoice
  {
    private Decimal amount;
    private string currency;
    private string date;
    private Decimal exchangeRate;

    [XmlElement("amount")]
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

    [XmlElement("currency")]
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

    [XmlElement("date")]
    public string Date
    {
      get
      {
        return this.date;
      }
      set
      {
        this.date = value;
      }
    }

    [XmlElement("exchangeRate")]
    public Decimal ExchangeRate
    {
      get
      {
        return this.exchangeRate;
      }
      set
      {
        this.exchangeRate = value;
      }
    }
  }
}
