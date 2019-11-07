// Decompiled with JetBrains decompiler
// Type: MobilpayEncryptDecrypt.Mobilpay_Payment_Request_Abstract
// Assembly: MobilpayEncryptDecrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E9668A4E-41EC-4174-9AFB-E80FB974BD68
// Assembly location: C:\Users\bogdan.hatis\Desktop\WebSite1\MobilpayEncryptDecrypt.dll

using System;
using System.Xml.Serialization;

namespace MobilpayEncryptDecrypt
{
  [Serializable]
  public class Mobilpay_Payment_Request_Abstract
  {
    private string signature;
    private string service;
    private string orderId;
    private string timestamp;
    private string type;
    private Mobilpay_Payment_Request_Url url;
    private Mobilpay_Payment_ParamsCollection parameters;
    private Mobilpay_Payment_Confirm confirm;

    [XmlElement("signature")]
    public string Signature
    {
      get
      {
        return this.signature;
      }
      set
      {
        this.signature = value;
      }
    }

    [XmlElement("service")]
    public string Service
    {
      get
      {
        return this.service;
      }
      set
      {
        this.service = value;
      }
    }

    [XmlAttribute("type")]
    public string Type
    {
      get
      {
        return this.type;
      }
      set
      {
        this.type = value;
      }
    }

    [XmlAttribute("id")]
    public string OrderId
    {
      get
      {
        return this.orderId;
      }
      set
      {
        this.orderId = value;
      }
    }

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

    [XmlElement("url")]
    public Mobilpay_Payment_Request_Url Url
    {
      get
      {
        return this.url;
      }
      set
      {
        this.url = value;
      }
    }

    [XmlArrayItem("param")]
    [XmlArray("params")]
    public Mobilpay_Payment_ParamsCollection Params
    {
      get
      {
        return this.parameters;
      }
      set
      {
        this.parameters = value;
      }
    }

    [XmlElement("mobilpay")]
    public Mobilpay_Payment_Confirm Confirm
    {
      get
      {
        return this.confirm;
      }
      set
      {
        this.confirm = value;
      }
    }
  }
}
