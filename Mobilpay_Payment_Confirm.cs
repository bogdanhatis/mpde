// Decompiled with JetBrains decompiler
// Type: MobilpayEncryptDecrypt.Mobilpay_Payment_Confirm
// Assembly: MobilpayEncryptDecrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E9668A4E-41EC-4174-9AFB-E80FB974BD68
// Assembly location: C:\Users\bogdan.hatis\Desktop\WebSite1\MobilpayEncryptDecrypt.dll

using System;
using System.Xml.Serialization;

namespace MobilpayEncryptDecrypt
{
  [Serializable]
  public class Mobilpay_Payment_Confirm
  {
    private string timestamp;
    private string crc;
    private string action;
    private Decimal original_amount;
    private Decimal processed_amount;
    private int purchase;
    private string payerMsisdn;
    private string payerOprCode;
    private string panMasked;
    private string tokenId;
    private string tokenExpirationDate;
    private Mobilpay_Payment_Error error;
    private Mobilpay_IssueInvoice issueInvoice;

    [XmlAttribute("timestamp")]
    public string TimeStamp
    {
      get
      {
        return this.timestamp;
      }
      set
      {
        this.timestamp = value;
      }
    }

    [XmlAttribute("crc")]
    public string Crc
    {
      get
      {
        return this.crc;
      }
      set
      {
        this.crc = value;
      }
    }

    [XmlElement("action")]
    public string Action
    {
      get
      {
        return this.action;
      }
      set
      {
        this.action = value;
      }
    }

    [XmlElement("original_amount")]
    public Decimal Original_Amount
    {
      get
      {
        return this.original_amount;
      }
      set
      {
        this.original_amount = value;
      }
    }

    [XmlElement("processed_amount")]
    public Decimal Processed_Amount
    {
      get
      {
        return this.processed_amount;
      }
      set
      {
        this.processed_amount = value;
      }
    }

    [XmlElement("purchase")]
    public int Purchase
    {
      get
      {
        return this.purchase;
      }
      set
      {
        this.purchase = value;
      }
    }

    [XmlElement("paid_by_phone")]
    public string PayerMsisdn
    {
      get
      {
        return this.payerMsisdn;
      }
      set
      {
        this.payerMsisdn = value;
      }
    }

    [XmlElement("opr_code")]
    public string PayerOprCode
    {
      get
      {
        return this.payerOprCode;
      }
      set
      {
        this.payerOprCode = value;
      }
    }

    [XmlElement("pan_masked")]
    public string PanMasked
    {
      get
      {
        return this.panMasked;
      }
      set
      {
        this.panMasked = value;
      }
    }

    [XmlElement("token_id")]
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

    [XmlElement("token_expiration_date")]
    public string TokenExpirationDate
    {
      get
      {
        return this.tokenExpirationDate;
      }
      set
      {
        this.tokenExpirationDate = value;
      }
    }

    [XmlElement("error")]
    public Mobilpay_Payment_Error Error
    {
      get
      {
        return this.error;
      }
      set
      {
        this.error = value;
      }
    }

    [XmlElement("issue_invoice")]
    public Mobilpay_IssueInvoice IssueInvoice
    {
      get
      {
        return this.issueInvoice;
      }
      set
      {
        this.issueInvoice = value;
      }
    }
  }
}
