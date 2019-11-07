// Decompiled with JetBrains decompiler
// Type: MobilpayEncryptDecrypt.Mobilpay_Payment_Invoice_Item
// Assembly: MobilpayEncryptDecrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E9668A4E-41EC-4174-9AFB-E80FB974BD68
// Assembly location: C:\Users\bogdan.hatis\Desktop\WebSite1\MobilpayEncryptDecrypt.dll

using System;
using System.Xml.Serialization;

namespace MobilpayEncryptDecrypt
{
  [Serializable]
  public class Mobilpay_Payment_Invoice_Item
  {
    private string code;
    private string name;
    private string measurment;
    private Decimal quantity;
    private Decimal price;
    private Decimal vat;

    [XmlElement("code")]
    public string Code
    {
      get
      {
        return this.code;
      }
      set
      {
        this.code = value;
      }
    }

    [XmlElement("name")]
    public string Name
    {
      get
      {
        return this.name;
      }
      set
      {
        this.name = value;
      }
    }

    [XmlElement("measurment")]
    public string Measurment
    {
      get
      {
        return this.measurment;
      }
      set
      {
        this.measurment = value;
      }
    }

    [XmlElement("quantity")]
    public Decimal Quantity
    {
      get
      {
        return this.quantity;
      }
      set
      {
        this.quantity = value;
      }
    }

    [XmlElement("price")]
    public Decimal Price
    {
      get
      {
        return this.price;
      }
      set
      {
        this.price = value;
      }
    }

    [XmlElement("vat")]
    public Decimal Vat
    {
      get
      {
        return this.vat;
      }
      set
      {
        this.vat = value;
      }
    }
  }
}
