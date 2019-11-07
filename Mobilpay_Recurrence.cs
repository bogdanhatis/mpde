// Decompiled with JetBrains decompiler
// Type: MobilpayEncryptDecrypt.Mobilpay_Recurrence
// Assembly: MobilpayEncryptDecrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E9668A4E-41EC-4174-9AFB-E80FB974BD68
// Assembly location: C:\Users\bogdan.hatis\Desktop\WebSite1\MobilpayEncryptDecrypt.dll

using System;
using System.Xml.Serialization;

namespace MobilpayEncryptDecrypt
{
  [Serializable]
  public class Mobilpay_Recurrence
  {
    private int nIntervalDay;
    private int nPaymentsNo;

    [XmlAttribute("interval_day")]
    public int IntervalDay
    {
      get
      {
        return this.nIntervalDay;
      }
      set
      {
        this.nIntervalDay = value;
      }
    }

    [XmlAttribute("payments_no")]
    public int PaymentsNo
    {
      get
      {
        return this.nPaymentsNo;
      }
      set
      {
        this.nPaymentsNo = value;
      }
    }
  }
}
