// small class to re-rout the output of the Console messages to a listbox
//
// ListBoxStreamWriter _writer = null;
//
// eg after  InitializeComponent();
// _writer = new ListBoxStreamWriter(log_listBox);
// Console.SetOut(_writer);
//
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;


//
//
//
public class ListBoxStreamWriter : TextWriter
{
    ListBox output = null;
    private StringBuilder line = new StringBuilder();

    //
    //
    //
    public ListBoxStreamWriter(ListBox output)
    {
        this.output = output;
    }


    //
    //
    //
    public override void Write(char value)
    {
        base.Write(value);

        if(value == '\n')
            return;

        line.Append(value);

        // writeln
        if (value == '\r')
        {            
            // add to listbox
            output.Items.Add(line.ToString());

            line = new StringBuilder();
        }
    }


    //
    //
    //
    public override Encoding Encoding
    {
        get { return System.Text.Encoding.UTF8; }
    }
}
