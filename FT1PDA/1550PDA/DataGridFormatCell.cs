using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace _1550PDA
{



 public class DataGridFormatCellEventArgs
    {
        private int _column;
        private int _row;
        private Font _font;
        private Brush _backBrush;
        private Brush _foreBrush;
        private bool _useBaseClassDrawing;


        public DataGridFormatCellEventArgs(int row, int col, Font font1, Brush backBrush, Brush foreBrush)
        {
            _row = row;
            _column = col;
            _font = font1;
            _backBrush = backBrush;
            _foreBrush = foreBrush;
            _useBaseClassDrawing = false;
        }

        public int Column
        {
        get{ return _column;}
        set{ _column = value;}
        }
        public int Row
        {
        get{ return _row;}
        set{ _row = value;}
        }
        public Font TextFont
        {
        get{ return _font;}
        set{ _font = value;}
        }

        public Brush BackBrush
        {
        get{ return _backBrush;}
        set{ _backBrush = value;}
        }
        public Brush ForeBrush
        {
        get{ return _foreBrush;}
        set{ _foreBrush = value;}
        }
        public bool UseBaseClassDrawing
        {
        get{ return _useBaseClassDrawing;}
        set{ _useBaseClassDrawing = value;}
        }

}

public class DataGridFormattableTextBoxColumn : System.Windows.Forms.DataGridTextBoxColumn
{
    Font theFont_Default = new System.Drawing.Font("Arial", 12, FontStyle.Regular);

    public delegate void FormatCellEventHandler(object sender, DataGridFormatCellEventArgs e);
    //in your handler, set the EnableValue to true or false, depending upon the row & col
    public event FormatCellEventHandler SetCellFormat;

    private int _col;

    public DataGridFormattableTextBoxColumn(int col)
    {
        _col = col;
    }
    public DataGridFormattableTextBoxColumn()
    {
        _col = 0;
    }

    protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
    {
        try
        {
            DataGridFormatCellEventArgs e = new DataGridFormatCellEventArgs(rowNum, this._col, theFont_Default, backBrush, foreBrush);
            if (SetCellFormat != null)
            {
                SetCellFormat(this, e);
            }
            if (e.UseBaseClassDrawing)
                base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
            else
            {
                g.FillRectangle(e.BackBrush, bounds);
                string theVal = string.Empty;
                System.Data.DataRowView theRV = (System.Data.DataRowView)source.List[rowNum];//(System.Data.DataRowView)source.List[rowNum];

                if (theRV[this.MappingName] != null) { theVal = theRV[this.MappingName].ToString(); }
                g.DrawString(theVal, e.TextFont, e.ForeBrush, bounds.X, bounds.Y);
            }
            //if (e.TextFont != null)
            //{ e.TextFont.Dispose(); }
        }
        catch
        {
        }
    }

    //protected override void Edit(System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Rectangle bounds, bool readOnly, string instantText, bool cellIsVisible)
    //{
    //    //comment to make cells unable to become editable
    //    base.Edit(source, rowNum, bounds, readOnly, instantText, cellIsVisible);
    //}

   }


}
