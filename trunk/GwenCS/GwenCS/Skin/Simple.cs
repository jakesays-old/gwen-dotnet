﻿using System;
using System.Drawing;

namespace Gwen.Skin
{
    public class Simple : Skin.Base
    {
        protected Color m_colBorderColor;
        protected Color m_colControlOutlineLight;
        protected Color m_colControlOutlineLighter;
        protected Color m_colBG;
        protected Color m_colBGDark;
        protected Color m_colControl;
        protected Color m_colControlBorderHighlight;
        protected Color m_colControlDarker;
        protected Color m_colControlOutlineNormal;
        protected Color m_colControlBright;
        protected Color m_colControlDark;
        protected Color m_colHighlightBG;
        protected Color m_colHighlightBorder;
        protected Color m_colToolTipBackground;
        protected Color m_colToolTipBorder;
        protected Color m_colModal;

        public Simple(Renderer.Base renderer) : base(renderer)
        {
            m_colBorderColor = Color.FromArgb(255, 80, 80, 80);
            m_colBG = Color.FromArgb(255, 248, 248, 248);
            m_colBGDark = Color.FromArgb(255, 235, 235, 235);

            m_colControl = Color.FromArgb(255, 240, 240, 240);
            m_colControlBright = Color.FromArgb(255, 255, 255, 255);
            m_colControlDark = Color.FromArgb(255, 214, 214, 214);
            m_colControlDarker = Color.FromArgb(255, 180, 180, 180);

            m_colControlOutlineNormal = Color.FromArgb(255, 112, 112, 112);
            m_colControlOutlineLight = Color.FromArgb(255, 144, 144, 144);
            m_colControlOutlineLighter = Color.FromArgb(255, 210, 210, 210);

            m_colHighlightBG = Color.FromArgb(255, 192, 221, 252);
            m_colHighlightBorder = Color.FromArgb(255, 51, 153, 255);

            m_colToolTipBackground = Color.FromArgb(255, 255, 255, 225);
            m_colToolTipBorder = Color.FromArgb(255, 0, 0, 0);

            m_colModal = Color.FromArgb(150, 25, 25, 25);

            m_DefaultFont.FaceName = "Microsoft Sans Serif";
            m_DefaultFont.Size = 11;
        }

        public override void DrawButton(Controls.Base control, bool bDepressed, bool bHovered, bool disabled)
        {
            int w = control.Width;
            int h = control.Height;

            DrawButton(w, h, bDepressed, bHovered);
        }

        public override void DrawMenuItem(Controls.Base control, bool bSubmenuOpen, bool bChecked)
        {
            Rectangle rect = control.RenderBounds;
            if (bSubmenuOpen || control.IsHovered)
            {
                m_Render.DrawColor = m_colHighlightBG;
                m_Render.DrawFilledRect(rect);

                m_Render.DrawColor = m_colHighlightBorder;
                m_Render.DrawLinedRect(rect);
            }

            if (bChecked)
            {
                m_Render.DrawColor = Color.FromArgb(255, 0, 0, 0);

                Rectangle r = new Rectangle(control.Width / 2 - 2, control.Height / 2 - 2, 5, 5);
                DrawCheck(r);
            }
        }

        public override void DrawMenuStrip(Controls.Base control)
        {
            int w = control.Width;
            int h = control.Height;

            m_Render.DrawColor = Color.FromArgb(255, 246, 248, 252);
            m_Render.DrawFilledRect(new Rectangle(0, 0, w, h));

            m_Render.DrawColor = Color.FromArgb(150, 218, 224, 241);

            m_Render.DrawFilledRect(Global.FloatRect(0, h * 0.4f, w, h * 0.6f));
            m_Render.DrawFilledRect(Global.FloatRect(0, h * 0.5f, w, h * 0.5f));
        }

        public override void DrawMenu(Controls.Base control, bool bPaddingDisabled)
        {
            int w = control.Width;
            int h = control.Height;

            m_Render.DrawColor = m_colControlBright;
            m_Render.DrawFilledRect(new Rectangle(0, 0, w, h));

            if (!bPaddingDisabled)
            {
                m_Render.DrawColor = m_colControl;
                m_Render.DrawFilledRect(new Rectangle(1, 0, 22, h));
            }

            m_Render.DrawColor = m_colControlOutlineNormal;
            m_Render.DrawLinedRect(new Rectangle(0, 0, w, h));
        }

        public override void DrawShadow(Controls.Base control)
        {
            int w = control.Width;
            int h = control.Height;

            int x = 4;
            int y = 6;

            m_Render.DrawColor = Color.FromArgb(10, 0, 0, 0);

            m_Render.DrawFilledRect(new Rectangle(x, y, w, h));
            x += 2;
            m_Render.DrawFilledRect(new Rectangle(x, y, w, h));
            y += 2;
            m_Render.DrawFilledRect(new Rectangle(x, y, w, h));
        }

        public virtual void DrawButton(int w, int h, bool bDepressed, bool bHovered, bool bSquared = false)
        {
            if (bDepressed) m_Render.DrawColor = m_colControlDark;
            else if (bHovered) m_Render.DrawColor = m_colControlBright;
            else m_Render.DrawColor = m_colControl;

            m_Render.DrawFilledRect(new Rectangle(1, 1, w - 2, h - 2));
            
            if (bDepressed) m_Render.DrawColor = m_colControlDark;
            else if (bHovered) m_Render.DrawColor = m_colControl;
            else m_Render.DrawColor = m_colControlDark;

            m_Render.DrawFilledRect(Global.FloatRect(1, h * 0.5f, w - 2, h * 0.5f - 2));

            if (!bDepressed)
            {
                m_Render.DrawColor = m_colControlBright;
            }
            else
            {
                m_Render.DrawColor = m_colControlDarker;
            }
            m_Render.DrawShavedCornerRect(new Rectangle(1, 1, w - 2, h - 2), bSquared);

            // Border
            m_Render.DrawColor = m_colControlOutlineNormal;
            m_Render.DrawShavedCornerRect(new Rectangle(0, 0, w, h), bSquared);
        }

        public override void DrawRadioButton(Controls.Base control, bool bSelected, bool bDepressed)
        {
            Rectangle rect = control.RenderBounds;

            // Inside colour
            if (control.IsHovered) m_Render.DrawColor = Color.FromArgb(255, 220, 242, 254);
            else m_Render.DrawColor = m_colControlBright;

            m_Render.DrawFilledRect(new Rectangle(1, 1, rect.Width - 2, rect.Height - 2));

            // Border
            if (control.IsHovered) m_Render.DrawColor = Color.FromArgb(255, 85, 130, 164);
            else m_Render.DrawColor = m_colControlOutlineLight;

            m_Render.DrawShavedCornerRect(rect);

            m_Render.DrawColor = Color.FromArgb(15, 0, 50, 60);
            m_Render.DrawFilledRect(new Rectangle(rect.X + 2, rect.Y + 2, rect.Width - 4, rect.Height - 4));
            m_Render.DrawFilledRect(Global.FloatRect(rect.X + 2, rect.Y + 2, rect.Width * 0.3f, rect.Height - 4));
            m_Render.DrawFilledRect(Global.FloatRect(rect.X + 2, rect.Y + 2, rect.Width - 4, rect.Height * 0.3f));

            if (control.IsHovered) m_Render.DrawColor = Color.FromArgb(255, 121, 198, 249);
            else m_Render.DrawColor = Color.FromArgb(50, 0, 50, 60);

            m_Render.DrawFilledRect(new Rectangle(rect.X + 2, rect.Y + 3, 1, rect.Height - 5));
            m_Render.DrawFilledRect(new Rectangle(rect.X + 3, rect.Y + 2, rect.Width - 5, 1));


            if (bSelected)
            {
                m_Render.DrawColor = Color.FromArgb(255, 40, 230, 30);
                m_Render.DrawFilledRect(new Rectangle(rect.X + 2, rect.Y + 2, rect.Width - 4, rect.Height - 4));
            }
        }

        public override void DrawCheckBox(Controls.Base control, bool bSelected, bool bDepressed)
        {
            Rectangle rect = control.RenderBounds;

            // Inside colour
            if (control.IsHovered) m_Render.DrawColor = Color.FromArgb(255, 220, 242, 254);
            else m_Render.DrawColor = m_colControlBright;

            m_Render.DrawFilledRect(rect);

            // Border
            if (control.IsHovered) m_Render.DrawColor = Color.FromArgb(255, 85, 130, 164);
            else m_Render.DrawColor = m_colControlOutlineLight;

            m_Render.DrawLinedRect(rect);

            m_Render.DrawColor = Color.FromArgb(15, 0, 50, 60);
            m_Render.DrawFilledRect(new Rectangle(rect.X + 2, rect.Y + 2, rect.Width - 4, rect.Height - 4));
            m_Render.DrawFilledRect(Global.FloatRect(rect.X + 2, rect.Y + 2, rect.Width * 0.3f, rect.Height - 4));
            m_Render.DrawFilledRect(Global.FloatRect(rect.X + 2, rect.Y + 2, rect.Width - 4, rect.Height * 0.3f));

            if (control.IsHovered) m_Render.DrawColor = Color.FromArgb(255, 121, 198, 249);
            else m_Render.DrawColor = Color.FromArgb(50, 0, 50, 60);

            m_Render.DrawFilledRect(new Rectangle(rect.X + 2, rect.Y + 2, 1, rect.Height - 4));
            m_Render.DrawFilledRect(new Rectangle(rect.X + 2, rect.Y + 2, rect.Width - 4, 1));

            if (bDepressed)
            {
                m_Render.DrawColor = Color.FromArgb(255, 100, 100, 100);
                Rectangle r = new Rectangle(control.Width / 2 - 2, control.Height / 2 - 2, 5, 5);
                DrawCheck(r);
            }
            else if (bSelected)
            {
                m_Render.DrawColor = Color.FromArgb(255, 0, 0, 0);
                Rectangle r = new Rectangle(control.Width / 2 - 2, control.Height / 2 - 2, 5, 5);
                DrawCheck(r);
            }
        }

        public override void DrawGroupBox(Controls.Base control, int textStart, int textHeight, int textWidth)
        {
            Rectangle rect = control.RenderBounds;

            rect.Y += Global.Trunc(textHeight * 0.5f);
            rect.Height -= Global.Trunc(textHeight * 0.5f);

            Color m_colDarker = Color.FromArgb(50, 0, 50, 60);
            Color m_colLighter = Color.FromArgb(150, 255, 255, 255);

            m_Render.DrawColor = m_colLighter;

            m_Render.DrawFilledRect(new Rectangle(rect.X + 1, rect.Y + 1, textStart - 3, 1));
            m_Render.DrawFilledRect(new Rectangle(rect.X + 1 + textStart + textWidth, rect.Y + 1,
                                                  rect.Width - textStart + textWidth - 2, 1));
            m_Render.DrawFilledRect(new Rectangle(rect.X + 1, (rect.Y + rect.Height) - 1, rect.Width - 2, 1));

            m_Render.DrawFilledRect(new Rectangle(rect.X + 1, rect.Y + 1, 1, rect.Height));
            m_Render.DrawFilledRect(new Rectangle((rect.X + rect.Width) - 2, rect.Y + 1, 1, rect.Height - 1));

            m_Render.DrawColor = m_colDarker;

            m_Render.DrawFilledRect(new Rectangle(rect.X + 1, rect.Y, textStart - 3, 1));
            m_Render.DrawFilledRect(new Rectangle(rect.X + 1 + textStart + textWidth, rect.Y,
                                                  rect.Width - textStart - textWidth - 2, 1));
            m_Render.DrawFilledRect(new Rectangle(rect.X + 1, (rect.Y + rect.Height) - 1, rect.Width - 2, 1));

            m_Render.DrawFilledRect(new Rectangle(rect.X, rect.Y + 1, 1, rect.Height - 1));
            m_Render.DrawFilledRect(new Rectangle((rect.X + rect.Width) - 1, rect.Y + 1, 1, rect.Height - 1));
        }

        public override void DrawTextBox(Controls.Base control)
        {
            Rectangle rect = control.RenderBounds;
            bool bHasFocus = control.HasFocus;

            // Box inside
            m_Render.DrawColor = Color.FromArgb(255, 255, 255, 255);
            m_Render.DrawFilledRect(new Rectangle(1, 1, rect.Width - 2, rect.Height - 2));

            m_Render.DrawColor = m_colControlOutlineLight;
            m_Render.DrawFilledRect(new Rectangle(rect.X + 1, rect.Y, rect.Width - 2, 1));
            m_Render.DrawFilledRect(new Rectangle(rect.X, rect.Y + 1, 1, rect.Height - 2));

            m_Render.DrawColor = m_colControlOutlineLighter;
            m_Render.DrawFilledRect(new Rectangle(rect.X + 1, (rect.Y + rect.Height) - 1, rect.Width - 2, 1));
            m_Render.DrawFilledRect(new Rectangle((rect.X + rect.Width) - 1, rect.Y + 1, 1, rect.Height - 2));

            if (bHasFocus)
            {
                m_Render.DrawColor = Color.FromArgb(150, 50, 200, 255);
                m_Render.DrawLinedRect(rect);
            }
        }

        public override void DrawTabButton(Controls.Base control, bool bActive, Pos dir)
        {
            Rectangle rect = control.RenderBounds;
            bool bHovered = control.IsHovered;

            if (bHovered) m_Render.DrawColor = m_colControlBright;
            else m_Render.DrawColor = m_colControl;

            m_Render.DrawFilledRect(new Rectangle(1, 1, rect.Width - 2, rect.Height - 1));

            if (bHovered) m_Render.DrawColor = m_colControl;
            else m_Render.DrawColor = m_colControlDark;

            m_Render.DrawFilledRect(Global.FloatRect(1, rect.Height*0.5f, rect.Width - 2, rect.Height*0.5f - 1));

            m_Render.DrawColor = m_colControlBright;
            m_Render.DrawShavedCornerRect(new Rectangle(1, 1, rect.Width - 2, rect.Height));

            m_Render.DrawColor = m_colBorderColor;

            m_Render.DrawShavedCornerRect(new Rectangle(0, 0, rect.Width, rect.Height));
        }

        public override void DrawTabControl(Controls.Base control)
        {
            Rectangle rect = control.RenderBounds;

            m_Render.DrawColor = m_colControl;
            m_Render.DrawFilledRect(rect);

            m_Render.DrawColor = m_colBorderColor;
            m_Render.DrawLinedRect(rect);

            //m_Render.DrawColor = m_colControl;
            //m_Render.DrawFilledRect(CurrentButtonRect);
        }

        public override void DrawWindow(Controls.Base control, int topHeight, bool inFocus)
        {
            Rectangle rect = control.RenderBounds;

            // Titlebar
            if (inFocus)
                m_Render.DrawColor = Color.FromArgb(230, 87, 164, 232);
            else
                m_Render.DrawColor = Color.FromArgb(230, Global.Trunc(87 * 0.70f), Global.Trunc(164 * 0.70f),
                                                    Global.Trunc(232 * 0.70f));

            int iBorderSize = 5;
            m_Render.DrawFilledRect(new Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, topHeight - 1));
            m_Render.DrawFilledRect(new Rectangle(rect.X + 1, rect.Y + topHeight - 1, iBorderSize,
                                                  rect.Height - 2 - topHeight));
            m_Render.DrawFilledRect(new Rectangle(rect.X + rect.Width - iBorderSize, rect.Y + topHeight - 1, iBorderSize,
                                                  rect.Height - 2 - topHeight));
            m_Render.DrawFilledRect(new Rectangle(rect.X + 1, rect.Y + rect.Height - iBorderSize, rect.Width - 2,
                                                  iBorderSize));

            // Main inner
            m_Render.DrawColor = Color.FromArgb(230, m_colControlDark.R, m_colControlDark.G, m_colControlDark.B);
            m_Render.DrawFilledRect(new Rectangle(rect.X + iBorderSize + 1, rect.Y + topHeight,
                                                  rect.Width - iBorderSize * 2 - 2,
                                                  rect.Height - topHeight - iBorderSize - 1));

            // Light inner border
            m_Render.DrawColor = Color.FromArgb(100, 255, 255, 255);
            m_Render.DrawShavedCornerRect(new Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2));

            // Dark line between titlebar and main
            m_Render.DrawColor = m_colBorderColor;

            // Inside border
            m_Render.DrawColor = m_colControlOutlineNormal;
            m_Render.DrawLinedRect(new Rectangle(rect.X + iBorderSize, rect.Y + topHeight - 1, rect.Width - 10,
                                                 rect.Height - topHeight - (iBorderSize - 1)));

            // Dark outer border
            m_Render.DrawColor = m_colBorderColor;
            m_Render.DrawShavedCornerRect(new Rectangle(rect.X, rect.Y, rect.Width, rect.Height));
        }

        public override void DrawWindowCloseButton(Controls.Base control, bool depressed, bool hovered, bool disabled)
        {
            // TODO
            DrawButton(control, depressed, hovered, disabled);
        }

        public override void DrawHighlight(Controls.Base control)
        {
            Rectangle rect = control.RenderBounds;
            m_Render.DrawColor = Color.FromArgb(255, 255, 100, 255);
            m_Render.DrawFilledRect(rect);
        }

        public override void DrawScrollBar(Controls.Base control, bool isHorizontal, bool bDepressed)
        {
            Rectangle rect = control.RenderBounds;
            if (bDepressed)
                m_Render.DrawColor = m_colControlDarker;
            else
                m_Render.DrawColor = m_colControlBright;
            m_Render.DrawFilledRect(rect);
        }

        public override void DrawScrollBarBar(Controls.Base control, bool bDepressed, bool isHovered, bool isHorizontal)
        {
            //TODO: something specialized
            DrawButton(control, bDepressed, isHovered, false);
        }

        public override void DrawTabTitleBar(Controls.Base control)
        {
            Rectangle rect = control.RenderBounds;

            m_Render.DrawColor = Color.FromArgb(255, 177, 193, 214);
            m_Render.DrawFilledRect(rect);

            m_Render.DrawColor = m_colBorderColor;
            rect.Height += 1;
            m_Render.DrawLinedRect(rect);
        }

        public override void DrawProgressBar(Controls.Base control, bool isHorizontal, float progress)
        {
            Rectangle rect = control.RenderBounds;
            Color FillColour = Color.FromArgb(255, 0, 211, 40);

            if (isHorizontal)
            {
                //Background
                m_Render.DrawColor = m_colControlDark;
                m_Render.DrawFilledRect(new Rectangle(1, 1, rect.Width - 2, rect.Height - 2));

                //Right half
                m_Render.DrawColor = FillColour;
                m_Render.DrawFilledRect(Global.FloatRect(1, 1, rect.Width * progress - 2, rect.Height - 2));

                m_Render.DrawColor = Color.FromArgb(150, 255, 255, 255);
                m_Render.DrawFilledRect(Global.FloatRect(1, 1, rect.Width - 2, rect.Height * 0.45f));
            }
            else
            {
                //Background 
                m_Render.DrawColor = m_colControlDark;
                m_Render.DrawFilledRect(new Rectangle(1, 1, rect.Width - 2, rect.Height - 2));

                //Top half
                m_Render.DrawColor = FillColour;
                m_Render.DrawFilledRect(Global.FloatRect(1, 1 + (rect.Height * (1 - progress)), rect.Width - 2,
                                                         rect.Height * progress - 2));

                m_Render.DrawColor = Color.FromArgb(150, 255, 255, 255);
                m_Render.DrawFilledRect(Global.FloatRect(1, 1, rect.Width * 0.45f, rect.Height - 2));
            }

            m_Render.DrawColor = Color.FromArgb(150, 255, 255, 255);
            m_Render.DrawShavedCornerRect(new Rectangle(1, 1, rect.Width - 2, rect.Height - 2));

            m_Render.DrawColor = Color.FromArgb(70, 255, 255, 255);
            m_Render.DrawShavedCornerRect(new Rectangle(2, 2, rect.Width - 4, rect.Height - 4));

            m_Render.DrawColor = m_colBorderColor;
            m_Render.DrawShavedCornerRect(rect);
        }

        public override void DrawListBox(Controls.Base control)
        {
            Rectangle rect = control.RenderBounds;

            m_Render.DrawColor = m_colControlBright;
            m_Render.DrawFilledRect(rect);

            m_Render.DrawColor = m_colBorderColor;
            m_Render.DrawLinedRect(rect);
        }

        public override void DrawListBoxLine(Controls.Base control, bool bSelected, bool even)
        {
            Rectangle rect = control.RenderBounds;

            if (bSelected)
            {
                m_Render.DrawColor = m_colHighlightBorder;
                m_Render.DrawFilledRect(rect);
            }
            else if (control.IsHovered)
            {
                m_Render.DrawColor = m_colHighlightBG;
                m_Render.DrawFilledRect(rect);
            }
        }

        public override void DrawSlider(Controls.Base control, bool bIsHorizontal, int numNotches, int barSize)
        {
            Rectangle rect = control.RenderBounds;
            Rectangle notchRect = rect;

            if (bIsHorizontal)
            {
                rect.Y += Global.Trunc(rect.Height * 0.4f);
                rect.Height -= Global.Trunc(rect.Height * 0.8f);
            }
            else
            {
                rect.X += Global.Trunc(rect.Width * 0.4f);
                rect.Width -= Global.Trunc(rect.Width * 0.8f);
            }

            m_Render.DrawColor = m_colBGDark;
            m_Render.DrawFilledRect(rect);

            m_Render.DrawColor = m_colControlDarker;
            m_Render.DrawLinedRect(rect);
        }

        public override void DrawComboBox(Controls.Base control, bool down, bool open)
        {
            DrawTextBox(control);
        }

        public override void DrawKeyboardHighlight(Controls.Base control, Rectangle r, int iOffset)
        {
            Rectangle rect = r;

            rect.X += iOffset;
            rect.Y += iOffset;
            rect.Width -= iOffset * 2;
            rect.Height -= iOffset * 2;

            //draw the top and bottom
            bool skip = true;
            for (int i = 0; i < rect.Width * 0.5; i++)
            {
                m_Render.DrawColor = Color.FromArgb(255, 0, 0, 0);
                if (!skip)
                {
                    m_Render.DrawPixel(rect.X + (i * 2), rect.Y);
                    m_Render.DrawPixel(rect.X + (i * 2), rect.Y + rect.Height - 1);
                }
                else
                    skip = !skip;
            }
            skip = false;
            for (int i = 0; i < rect.Height * 0.5; i++)
            {
                m_Render.DrawColor = Color.FromArgb(255, 0, 0, 0);
                if (!skip)
                {
                    m_Render.DrawPixel(rect.X, rect.Y + i * 2);
                    m_Render.DrawPixel(rect.X + rect.Width - 1, rect.Y + i * 2);
                }
                else
                    skip = !skip;
            }
        }

        public override void DrawToolTip(Controls.Base control)
        {
            Rectangle rct = control.RenderBounds;
            rct.X -= 3;
            rct.Y -= 3;
            rct.Width += 6;
            rct.Height += 6;

            m_Render.DrawColor = m_colToolTipBackground;
            m_Render.DrawFilledRect(rct);

            m_Render.DrawColor = m_colToolTipBorder;
            m_Render.DrawLinedRect(rct);
        }

        public override void DrawScrollButton(Controls.Base control, Pos iDirection, bool bDepressed, bool hovered, bool disabled)
        {
            DrawButton(control, bDepressed, false, false);

            m_Render.DrawColor = Color.FromArgb(240, 0, 0, 0);

            Rectangle r = new Rectangle(control.Width / 2 - 2, control.Height / 2 - 2, 5, 5);

            if (iDirection == Pos.Top) DrawArrowUp(r);
            else if (iDirection == Pos.Bottom) DrawArrowDown(r);
            else if (iDirection == Pos.Left) DrawArrowLeft(r);
            else DrawArrowRight(r);
        }

        public override void DrawComboBoxArrow(Controls.Base control, bool hovered, bool depressed, bool open, bool disabled)
        {
            //DrawButton( control.Width, control.Height, bDepressed, false, true );

            m_Render.DrawColor = Color.FromArgb(240, 0, 0, 0);

            Rectangle r = new Rectangle(control.Width / 2 - 2, control.Height / 2 - 2, 5, 5);
            DrawArrowDown(r);
        }

        public override void DrawNumericUpDownButton(Controls.Base control, bool bDepressed, bool bUp)
        {
            //DrawButton( control.Width, control.Height, bDepressed, false, true );

            m_Render.DrawColor = Color.FromArgb(240, 0, 0, 0);

            Rectangle r = new Rectangle(control.Width / 2 - 2, control.Height / 2 - 2, 5, 5);

            if (bUp) DrawArrowUp(r);
            else DrawArrowDown(r);
        }

        public override void DrawTreeButton(Controls.Base control, bool bOpen)
        {
            Rectangle rect = control.RenderBounds;
            rect.X += 2;
            rect.Y += 2;
            rect.Width -= 4;
            rect.Height -= 4;

            m_Render.DrawColor = m_colControlBright;
            m_Render.DrawFilledRect(rect);

            m_Render.DrawColor = m_colBorderColor;
            m_Render.DrawLinedRect(rect);

            m_Render.DrawColor = m_colBorderColor;

            if (!bOpen) // ! because the button shows intention, not the current state
                m_Render.DrawFilledRect(new Rectangle(rect.X + rect.Width / 2, rect.Y + 2, 1, rect.Height - 4));

            m_Render.DrawFilledRect(new Rectangle(rect.X + 2, rect.Y + rect.Height / 2, rect.Width - 4, 1));
        }

        public override void DrawTreeControl(Controls.Base control)
        {
            Rectangle rect = control.RenderBounds;

            m_Render.DrawColor = m_colControlBright;
            m_Render.DrawFilledRect(rect);

            m_Render.DrawColor = m_colBorderColor;
            m_Render.DrawLinedRect(rect);
        }

        public override void DrawTreeNode(Controls.Base ctrl, bool bOpen, bool bSelected, int iLabelHeight, int iLabelWidth, int iHalfWay, int iLastBranch, bool bIsRoot)
        {
            if (bSelected)
            {
                Renderer.DrawColor = Color.FromArgb(100, 0, 150, 255);
                Renderer.DrawFilledRect(new Rectangle(17, 0, iLabelWidth + 2, iLabelHeight - 1));
                Renderer.DrawColor = Color.FromArgb(200, 0, 150, 255);
                Renderer.DrawLinedRect(new Rectangle(17, 0, iLabelWidth + 2, iLabelHeight - 1));
            }

            base.DrawTreeNode(ctrl, bOpen, bSelected, iLabelHeight, iLabelWidth, iHalfWay, iLastBranch, bIsRoot);
        }

        public override void DrawStatusBar(Controls.Base control)
        {
            // todo
        }

        public override void DrawColorDisplay(Controls.Base control, Color color)
        {
            Rectangle rect = control.RenderBounds;

            if (color.A != 255)
            {
                Renderer.DrawColor = Color.FromArgb(255, 255, 255, 255);
                Renderer.DrawFilledRect(rect);

                Renderer.DrawColor = Color.FromArgb(128, 128, 128, 128);

                Renderer.DrawFilledRect(Global.FloatRect(0, 0, rect.Width * 0.5f, rect.Height * 0.5f));
                Renderer.DrawFilledRect(Global.FloatRect(rect.Width * 0.5f, rect.Height * 0.5f, rect.Width * 0.5f,
                                                         rect.Height * 0.5f));
            }

            Renderer.DrawColor = color;
            Renderer.DrawFilledRect(rect);

            Renderer.DrawColor = Color.FromArgb(255, 0, 0, 0);
            Renderer.DrawLinedRect(rect);
        }

        public override void DrawModalControl(Controls.Base control)
        {
            if (control.ShouldDrawBackground)
            {
                Rectangle rect = control.RenderBounds;
                Renderer.DrawColor = m_colModal;
                Renderer.DrawFilledRect(rect);
            }
        }

        public override void DrawMenuDivider(Controls.Base control)
        {
            Rectangle rect = control.RenderBounds;
            Renderer.DrawColor = m_colBGDark;
            Renderer.DrawFilledRect(rect);
            Renderer.DrawColor = m_colControlDarker;
            Renderer.DrawLinedRect(rect);
        }

        public override void DrawMenuRightArrow(Controls.Base control)
        {
            DrawArrowRight(control.RenderBounds);
        }

        public override void DrawSliderButton(Controls.Base control, bool depressed, bool horizontal)
        {
            DrawButton(control, depressed, control.IsHovered, control.IsDisabled);
        }

        public override void DrawCategoryHolder(Controls.Base control)
        {
            // todo
        }

        public override void DrawCategoryInner(Controls.Base control, bool collapsed)
        {
            // todo
        }
    }
}