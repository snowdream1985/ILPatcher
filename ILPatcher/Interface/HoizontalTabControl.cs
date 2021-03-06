﻿using System.Drawing;
using System.Windows.Forms;

namespace ILPatcher.Interface
{
	class HoizontalTabControl : TabControl
	{
		public HoizontalTabControl()
		{
			Alignment = TabAlignment.Left;
			DrawMode = TabDrawMode.OwnerDrawFixed;
			ItemSize = new Size(20, 100);
			SizeMode = TabSizeMode.Fixed;
		}

		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			base.OnDrawItem(e);
			Graphics g = e.Graphics;
			Brush _textBrush;

			// Get the item from the collection.
			TabPage _tabPage = TabPages[e.Index];

			// Get the real bounds for the tab rectangle.
			Rectangle _tabBounds = GetTabRect(e.Index);

			if (e.State == DrawItemState.Selected)
			{

				_textBrush = Brushes.DarkBlue;
				//g.FillRectangle(Brushes.Gray, e.Bounds);
			}
			else
			{
				_textBrush = Brushes.Black;
			}
			g.FillRectangle(SystemBrushes.Control, e.Bounds);

			// Draw string. Center the text.
			using (StringFormat _stringFlags = new StringFormat())
			{
				_stringFlags.Alignment = StringAlignment.Center;
				_stringFlags.LineAlignment = StringAlignment.Center;
				g.DrawString(_tabPage.Text, Font, _textBrush, _tabBounds, _stringFlags);
			}
		}

	}
}
