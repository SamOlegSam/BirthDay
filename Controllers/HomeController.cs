using BirthDay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace BirthDay.Controllers
{
    public class HomeController : Controller
    {
        public GENERALEntities db = new GENERALEntities();
        public GENERALEntities1 db1 = new GENERALEntities1();
        public ActionResult Index()
        {

            //List<get_ok_days> birthday = new List<get_ok_days>();
            //birthday = db.get_ok_days.OrderBy(f => f.datbegin.Month).ThenBy(g => g.datbegin.Day).ToList();
            //return View(birthday);

            //List<C_get_ok_days777> birthday = new List<C_get_ok_days777>();
            //birthday = db1.C_get_ok_days777.OrderBy(f => f.datbegin.Month).ThenBy(g => g.datbegin.Day).ToList();
            //return View(birthday);

            List<C_get_ok_days777> birthday = new List<C_get_ok_days777>();
            birthday = db1.C_get_ok_days777.OrderBy(h => h.dmonth).ThenBy(j => j.dday).AsNoTracking().Where(h=>h.datbegin!=null).ToList();
            ViewBag.vvv = birthday;
            return View(birthday);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //!!!!!!!Формирование отчета PDF//
        public ActionResult ExportGroup(string dataS, string dataPo)
        {

            MemoryStream workStream = new MemoryStream();

            // Имя создаваемого файла. 
            string strPDFFileName = string.Format("BirthDay.pdf");
            Document doc = new Document();
           // doc.SetPageSize(PageSize.A4.Rotate());
            PdfWriter.GetInstance(doc, workStream).CloseStream = false;
                                   
            List<get_ok_days> Vac = new List<get_ok_days>();
                        
                Vac = db.get_ok_days.OrderBy(q => q.datbegin.Month).ThenBy(w => w.datbegin.Day).ToList();
                List<get_ok_days> H_after_filter = new List<get_ok_days>();                     
              
            
                H_after_filter = Vac.Where(d => d.datbegin.Day >= Convert.ToDateTime(dataS).Day & d.datbegin.Month >= Convert.ToDateTime(dataS).Month & d.datbegin.Day <= Convert.ToDateTime(dataPo).Day & d.datbegin.Month <= Convert.ToDateTime(dataPo).Month).ToList();
            
            
            // Подключение русскоязычного шрифта.
            string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");
            BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font f12 = new Font(baseFont, 12);
            Font f14 = new Font(baseFont, 14);
            Font f16 = new Font(baseFont, 16);
            Font f12Bold = new Font(baseFont, 12, Font.BOLD);
            Font f18Bold = new Font(baseFont, 18, Font.BOLD);
            Font f20Bold = new Font(baseFont, 20, Font.BOLD);

            // Открытие документа.
            doc.Open();

            // Создание элементов.
            Paragraph par1 = new Paragraph("Открытое акционерное общество 'Гомельтранснефть Дружба'", f12Bold);
            Paragraph par2 = new Paragraph("дни рождения сотрудников", f20Bold);
            Paragraph par3 = new Paragraph("c " + dataS +" по "+ dataPo , f12Bold);
            
            par1.Alignment = Element.ALIGN_CENTER;
            par2.Alignment = Element.ALIGN_CENTER;
            par3.Alignment = Element.ALIGN_CENTER;
            

            
            PdfPTable table = new PdfPTable(4);
            PdfPCell cell = new PdfPCell();
            table.WidthPercentage = 100f;

            float[] columnWidths = new float[] { 13f, 7f, 40f, 40f};
            table.SetWidths(columnWidths);

                            //--------------------Шапка таблицы -------------------------------//
                            cell = new PdfPCell(new Phrase("ДАТА", f12Bold));
                            table.AddCell(cell);

                            cell = new PdfPCell(new Phrase("ВОЗРАСТ", f12Bold));
                            table.AddCell(cell);

                            cell = new PdfPCell(new Phrase("ФИО", f12Bold));
                            table.AddCell(cell);

                            cell = new PdfPCell(new Phrase("ДОЛЖНОСТЬ", f12Bold));
                            table.AddCell(cell);


            //------------------Конец шапки таблицы ---------------------------------------//
                            foreach (var sotr in H_after_filter)
            {
                //-------------------------Таблица с сотрудниками ----------------------//
                cell = new PdfPCell(new Phrase(sotr.datbegin.ToShortDateString(), f12));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(sotr.Aget.ToString(), f12Bold));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(sotr.fio, f12Bold));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(sotr.doljn, f12));
                table.AddCell(cell);



                //-------------------------------Конец таблицы с сотрудниками ------------------------//
            }




            // Добавление элементов в документ.
            doc.Add(par1);
            doc.Add(par2);
            doc.Add(par3);
            
            doc.Add(new Paragraph(" ", f16));
            doc.Add(table);

            //doc.Add(table);
            // Закрытие документа.  
            //writer.Close();
            doc.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;


            return File(workStream, "application/pdf", strPDFFileName);
        }

        public ActionResult GetLastName(string str)
        {
            //List<get_ok_days> phoneList = new List<get_ok_days>();
            //phoneList = db.get_ok_days.Where(p => p.fio.Contains(str) || p.doljn.Contains(str)).ToList();
            //ViewBag.phone = phoneList;
            //return View(phoneList);

            List<C_get_ok_days777> phoneList = new List<C_get_ok_days777>();
            phoneList = db1.C_get_ok_days777.Where(p => p.fio.Contains(str) || p.doljn.Contains(str)).ToList();
            ViewBag.phone = phoneList;
            return View(phoneList);
        }
    }
}