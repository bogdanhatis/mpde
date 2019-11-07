// Decompiled with JetBrains decompiler
// Type: MobilpayEncryptDecrypt.Mobilpay_Payment_Invoice
// Assembly: MobilpayEncryptDecrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E9668A4E-41EC-4174-9AFB-E80FB974BD68
// Assembly location: C:\Users\bogdan.hatis\Desktop\WebSite1\MobilpayEncryptDecrypt.dll

using System;
using System.Xml.Serialization;

namespace MobilpayEncryptDecrypt
{
  [Serializable]
  public class Mobilpay_Payment_Invoice
  {
    private string currency;
    private Decimal amount;
    private string details;
    private Mobilpay_Payment_Request_Contact_Info contactInfo;
    private Mobilpay_Payment_ItemCollection items;
    private Mobilpay_Payment_Exchange_RateCollection exchangeRates;
    private string tokenId;

    [XmlAttribute("currency")]
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

    [XmlElement("details")]
    public string Details
    {
      get
      {
        return this.details;
      }
      set
      {
        this.details = value;
      }
    }

    [XmlAttribute("token_id")]
    public string TokenId
    {
      get
      {
        return this.tokenId;
      }
      set
      {
        this.tokenId = value;
      }
    }

    [XmlElement("contact_info")]
    public Mobilpay_Payment_Request_Contact_Info ContactInfo
    {
      get
      {
        return this.contactInfo;
      }
      set
      {
        this.contactInfo = value;
      }
    }

    [XmlArrayItem("item")]
    [XmlArray("items")]
    public Mobilpay_Payment_ItemCollection Items
    {
      get
      {
        return this.items;
      }
      set
      {
        this.items = value;
      }
    }

    [XmlArrayItem("rate")]
    [XmlArray("exchange_rates")]
    public Mobilpay_Payment_Exchange_RateCollection ExchangeRates
    {
      get
      {
        return this.exchangeRates;
      }
      set
      {
        this.exchangeRates = value;
      }
    }

    [XmlAttribute("installments")]
    public string Installments { get; set; }

    [XmlAttribute("selected_installments")]
    public string SelectedInstallments { get; set; }
  }
}
