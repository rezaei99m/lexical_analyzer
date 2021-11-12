using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lexical_Analyzer.Business_Layer
{
    public static class UI
    {
        //So here if we want to add show we have to use rowCounter property and for using it we should use it in the a loop 
        public static void fnDisplayTokens(Grid token, Token temp, int rowCounter)
        {
            token.RowDefinitions.Add(new RowDefinition());

            TextBlock Token = new TextBlock();
            Token.Text = "(" + temp.fnGetAttributeName() + ", " + temp.fnGetAttributeValue() + ")";
            Token.TextWrapping = TextWrapping.Wrap;
            Token.Margin = new Thickness(5, 0, 5, 5);
            Token.FontSize = 30;
            Token.SetValue(Grid.RowProperty, rowCounter);

            token.Children.Add(Token);
        }

        public static void fnDisplaySymboleTable(Grid symboleTable, Token temp/*Lexicer lexicalAnalyzer*/, int rowCounter)
        {
            symboleTable.RowDefinitions.Add(new RowDefinition());

            Grid showToken = new Grid();
            showToken.Margin = new Thickness(0, 0, 0, 5);
            showToken.Height = double.NaN;  //For autoing height of the grid.
            showToken.ColumnDefinitions.Add(new ColumnDefinition());
            showToken.ColumnDefinitions.Add(new ColumnDefinition());
            showToken.ColumnDefinitions.Add(new ColumnDefinition());
            showToken.ColumnDefinitions[0].Width = new GridLength(50);

            TextBlock NO = new TextBlock();
            showToken.Children.Add(NO);
            NO.SetValue(Grid.ColumnProperty, 0);
            NO.FontSize = 20;
            NO.Margin = new Thickness(0, 0, 0, 0);
            NO.Text = rowCounter.ToString();

            TextBlock Name = new TextBlock();
            showToken.Children.Add(Name);
            Name.SetValue(Grid.ColumnProperty, 1);
            Name.FontSize = 20;
            Name.TextWrapping = TextWrapping.Wrap;
            Name.Text = temp.fnGetAttributeName();
            Name.HorizontalAlignment = HorizontalAlignment.Left;

            TextBlock Value = new TextBlock();
            showToken.Children.Add(Value);
            Value.SetValue(Grid.ColumnProperty, 2);
            Value.FontSize = 20;
            Value.Text = temp.fnGetAttributeValue();
            Name.HorizontalAlignment = HorizontalAlignment.Left;

            //Canvas Line = new Canvas();
            //Line.Height = 2;
            //Line.VerticalAlignment = VerticalAlignment.Bottom;
            //Line.Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            //Line.SetValue(Grid.ColumnSpanProperty, 3);
            //showToken.Children.Add(Line);

            showToken.SetValue(Grid.RowProperty, rowCounter);
            symboleTable.Children.Add(showToken);
        }

        public static void fnDisplayError(Grid errorList, string Error, int rowCounter)
        {
            errorList.RowDefinitions.Add(new RowDefinition());

            TextBlock textBoxError = new TextBlock();
            textBoxError.Text = Error;
            errorList.Children.Add(textBoxError);
            textBoxError.SetValue(Grid.RowProperty, rowCounter);
            textBoxError.FontSize = 20;
            textBoxError.FontFamily = new FontFamily("Segoe Print");

            //Canvas line = new Canvas();
            //line.Height = 3;
            //line.VerticalAlignment = VerticalAlignment.Bottom;
            //line.Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            //line.SetValue(Grid.RowProperty, rowCounter);

            //errorList.Children.Add(line);
        }

        //we need to show in the number table
    }
}
