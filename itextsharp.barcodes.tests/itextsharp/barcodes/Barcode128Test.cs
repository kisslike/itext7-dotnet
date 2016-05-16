using System;
using NUnit.Framework;
using iTextSharp.Kernel.Pdf;
using iTextSharp.Kernel.Pdf.Canvas;
using iTextSharp.Kernel.Utils;
using iTextSharp.Test;

namespace iTextSharp.Barcodes
{
	public class Barcode128Test : ExtendedITextTest
	{
		public const String sourceFolder = "../../resources/itextsharp/barcodes/";

		public const String destinationFolder = "test/itextsharp/barcodes/Barcode128/";

		[TestFixtureSetUp]
		public static void BeforeClass()
		{
			CreateDestinationFolder(destinationFolder);
		}

		/// <exception cref="System.IO.IOException"/>
		/// <exception cref="iTextSharp.Kernel.PdfException"/>
		/// <exception cref="System.Exception"/>
		[NUnit.Framework.Test]
		public virtual void Barcode01Test()
		{
			String filename = "barcode128_01.pdf";
			PdfWriter writer = new PdfWriter(destinationFolder + filename);
			PdfDocument document = new PdfDocument(writer);
			PdfPage page = document.AddNewPage();
			PdfCanvas canvas = new PdfCanvas(page);
			Barcode1D barcode = new Barcode128(document);
			barcode.SetCodeType(Barcode128.CODE128);
			barcode.SetCode("9781935182610");
			barcode.SetTextAlignment(Barcode1D.ALIGN_LEFT);
			barcode.PlaceBarcode(canvas, iTextSharp.Kernel.Color.Color.BLACK, iTextSharp.Kernel.Color.Color
				.BLACK);
			document.Close();
			NUnit.Framework.Assert.IsNull(new CompareTool().CompareByContent(destinationFolder
				 + filename, sourceFolder + "cmp_" + filename, destinationFolder, "diff_"));
		}

		/// <exception cref="System.IO.IOException"/>
		/// <exception cref="iTextSharp.Kernel.PdfException"/>
		/// <exception cref="System.Exception"/>
		[NUnit.Framework.Test]
		public virtual void Barcode02Test()
		{
			String filename = "barcode128_02.pdf";
			PdfWriter writer = new PdfWriter(destinationFolder + filename);
			PdfReader reader = new PdfReader(sourceFolder + "DocumentWithTrueTypeFont1.pdf");
			PdfDocument document = new PdfDocument(reader, writer);
			PdfCanvas canvas = new PdfCanvas(document.GetLastPage());
			Barcode1D barcode = new Barcode128(document);
			barcode.SetCodeType(Barcode128.CODE128);
			barcode.SetCode("9781935182610");
			barcode.SetTextAlignment(Barcode1D.ALIGN_LEFT);
			barcode.PlaceBarcode(canvas, iTextSharp.Kernel.Color.Color.BLACK, iTextSharp.Kernel.Color.Color
				.BLACK);
			document.Close();
			NUnit.Framework.Assert.IsNull(new CompareTool().CompareByContent(destinationFolder
				 + filename, sourceFolder + "cmp_" + filename, destinationFolder, "diff_"));
		}
	}
}
