//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BirthDay.Models
{
    using System;
    using System.Collections.Generic;

    public partial class C_get_ok_days777
    {
        public string fio { get; set; }
        //public Nullable<System.DateTime> datbegin { get; set; }
        public DateTime datbegin { get; set; }
        public Nullable<int> dday { get; set; }
        public Nullable<int> dmonth { get; set; }
        public string doljn { get; set; }
        public string kod { get; set; }
        public string podr { get; set; }

        public int Aget { get { return DateTime.Now.Year - Convert.ToInt32(datbegin.Year); } }
        public int Aget1 { get { return DateTime.Now.Year - Convert.ToInt32(datbegin.Year) - 1; } }

        public string datday { get { return Convert.ToString(datbegin.Day); } }
        public string datmonth { get { return  Convert.ToString(datbegin.Day); } }
        public string datyear { get { return Convert.ToString(DateTime.Now.Year); } }
        //public string datroj { get { return (datday + "." + datmonth + "." + datyear); } }
        //public string datroj { get { return (Convert.ToString(datbegin.Day) + "." + ("000" + Convert.ToString(datbegin.Month)).Remove(0, ("000" + Convert.ToString(datbegin.Month)).Length-2) + "."+ Convert.ToString(DateTime.Now.Year)); } }
        public string datroj { get { return (("000" + Convert.ToString(datbegin.Day)).Remove(0, ("000" + Convert.ToString(datbegin.Day)).Length - 2) + "." 
        + ("000" + Convert.ToString(datbegin.Month)).Remove(0, ("000" + Convert.ToString(datbegin.Month)).Length - 2) + "." + Convert.ToString(DateTime.Now.Year)); } }
        public DateTime datr { get { return Convert.ToDateTime(datroj); } }
        public int NowKol { get { return (DateTime.Now.DayOfYear); } }
        public int BirdKol1 { get { return (datbegin.DayOfYear); } }
        //public int BirdKol { get { return (datr.DayOfYear); } }
        public int BirdKol { get { return (Convert.ToDateTime(datr).DayOfYear); } }
        public int jjj { get { return (BirdKol - NowKol); } }

    }
}
