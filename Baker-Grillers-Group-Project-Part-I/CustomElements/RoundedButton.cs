using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Imaging;

namespace Baker_Grillers_Group_Project_Part_I.CustomElements
{
    [ToolboxItem(true)]
    [DesignerCategory("Code")]
    [Description("Button with rounded corners")]
    public class RoundedButton : Button
    {
        private bool _isSelected = false;
        private Color _selectedBackColor;
        private Color _selectedForeColor = Color.White;
        private Color _borderColor = Color.DarkGreen;
        private int _cornerRadius = 10;
        private int _borderSize = 2;
        private ContentAlignment _imageAlign = ContentAlignment.MiddleLeft;
        private Size _imageSize = new Size(24, 24);
        private int _imagePadding = 5;
        private Color _imageColor = Color.White;
        private Color _selectedImageColor = Color.White;
        private bool _applyImageColor = false;

        [Category("Appearance")]
        [Description("Indicates whether the button is in selected state")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("The radius of the button corners")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadius
        {
            get { return _cornerRadius; }
            set
            {
                _cornerRadius = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("The size of the border when button is selected")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderSize
        {
            get { return _borderSize; }
            set
            {
                _borderSize = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("The color of the border when button is selected")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("The background color when button is selected")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color SelectedBackColor
        {
            get { return _selectedBackColor; }
            set
            {
                _selectedBackColor = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("The text color when button is selected")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color SelectedForeColor
        {
            get { return _selectedForeColor; }
            set
            {
                _selectedForeColor = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("The alignment of the image within the button")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ContentAlignment ImageAlign
        {
            get { return _imageAlign; }
            set
            {
                _imageAlign = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("The size of the image")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Size ImageSize
        {
            get { return _imageSize; }
            set
            {
                _imageSize = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("The padding between the image and text")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int ImagePadding
        {
            get { return _imagePadding; }
            set
            {
                _imagePadding = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("The color to apply to the image")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ImageColor
        {
            get { return _imageColor; }
            set
            {
                _imageColor = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("The color to apply to the image when button is selected")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color SelectedImageColor
        {
            get { return _selectedImageColor; }
            set
            {
                _selectedImageColor = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Whether to apply the image color filter")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ApplyImageColor
        {
            get { return _applyImageColor; }
            set
            {
                _applyImageColor = value;
                this.Invalidate();
            }
        }

        public RoundedButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;

            _selectedBackColor = ControlPaint.Light(this.BackColor);

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            this.DoubleBuffered = true;
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);

            if (_selectedBackColor == Color.Empty)
            {
                _selectedBackColor = ControlPaint.Light(this.BackColor);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            e.Graphics.Clear(this.Parent != null ? this.Parent.BackColor : SystemColors.Control);

            GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(
                _borderSize,
                _borderSize,
                this.Width - (_borderSize * 2) - 1,
                this.Height - (_borderSize * 2) - 1);

            int radius = _cornerRadius;

            path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
            path.AddArc(rect.Right - (radius * 2), rect.Y, radius * 2, radius * 2, 270, 90);
            path.AddArc(rect.Right - (radius * 2), rect.Bottom - (radius * 2), radius * 2, radius * 2, 0, 90);
            path.AddArc(rect.X, rect.Bottom - (radius * 2), radius * 2, radius * 2, 90, 90);
            path.CloseAllFigures();

            using (SolidBrush brush = new SolidBrush(_isSelected ? _selectedBackColor : this.BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }

            // Border
            if (_isSelected)
            {
                using (Pen pen = new Pen(_borderColor, _borderSize))
                {
                    pen.Alignment = PenAlignment.Center;
                    pen.LineJoin = LineJoin.Round;
                    pen.EndCap = LineCap.Round;
                    pen.StartCap = LineCap.Round;

                    e.Graphics.DrawPath(pen, path);
                }
            }

            if (this.Image != null)
            {
                // Get text size - add a small buffer to ensure text fits
                SizeF textSize = e.Graphics.MeasureString(this.Text, this.Font);
                textSize.Width += 4; // Add a little extra width to prevent ellipsis

                // Calculate total width of image and text together
                int totalWidth = _imageSize.Width + 5 + (int)textSize.Width; // 5px padding between image and text

                // Calculate starting X to center the combined unit
                int startX = (this.Width - totalWidth) / 2;
                int centerY = this.Height / 2;

                // Draw the image (left side of centered unit)
                Rectangle imageRect = new Rectangle(
                    startX,
                    centerY - (_imageSize.Height / 2),
                    _imageSize.Width,
                    _imageSize.Height);

                if (_applyImageColor)
                {
                    // Create a colored version of the image
                    using (Image coloredImage = ApplyColorToImage(this.Image, _isSelected ? _selectedImageColor : _imageColor))
                    {
                        e.Graphics.DrawImage(coloredImage, imageRect);
                    }
                }
                else
                {
                    // Draw original image
                    e.Graphics.DrawImage(this.Image, imageRect);
                }

                // Draw the text (right side of centered unit) - using plain DrawString instead of with StringFormat
                using (SolidBrush brush = new SolidBrush(_isSelected ? _selectedForeColor : this.ForeColor))
                {
                    // Use a simple point-based DrawString which doesn't auto-truncate
                    PointF textPoint = new PointF(
                        startX + _imageSize.Width + 5, // 5px padding after image
                        centerY - (textSize.Height / 2)); // Center vertically

                    e.Graphics.DrawString(this.Text, this.Font, brush, textPoint);
                }
            }
            else
            {
                // No image, just draw centered text with more direct control
                using (SolidBrush brush = new SolidBrush(_isSelected ? _selectedForeColor : this.ForeColor))
                {
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    Rectangle textRect = new Rectangle(0, 0, this.Width, this.Height);
                    e.Graphics.DrawString(this.Text, this.Font, brush, textRect, sf);
                }
            }

            path.Dispose();
        }

        private Image ApplyColorToImage(Image originalImage, Color color)
        {
            // Create a blank bitmap with same dimensions
            Bitmap resultImage = new Bitmap(originalImage.Width, originalImage.Height);

            // Create color matrix that will colorize the image
            float[][] colorMatrixElements = {
                new float[] {0, 0, 0, 0, 0},
                new float[] {0, 0, 0, 0, 0},
                new float[] {0, 0, 0, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {color.R/255f, color.G/255f, color.B/255f, 0, 1}
            };

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            // Create an ImageAttributes object and set its color matrix
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);

            // Draw the original image onto the new image using the color matrix
            using (Graphics g = Graphics.FromImage(resultImage))
            {
                g.DrawImage(originalImage,
                    new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                    0, 0, originalImage.Width, originalImage.Height,
                    GraphicsUnit.Pixel, attributes);
            }

            return resultImage;
        }

        private Rectangle CalculateImageRectangle(ContentAlignment align, Size imgSize)
        {
            int x = 0, y = 0;

            // Calculate X position based on alignment
            switch (align)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                    x = _imagePadding;
                    break;

                case ContentAlignment.TopCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.BottomCenter:
                    x = (this.Width - imgSize.Width) / 2;
                    break;

                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                    x = this.Width - imgSize.Width - _imagePadding;
                    break;
            }

            // Calculate Y position based on alignment
            switch (align)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:
                    y = _imagePadding;
                    break;

                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleRight:
                    y = (this.Height - imgSize.Height) / 2;
                    break;

                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomRight:
                    y = this.Height - imgSize.Height - _imagePadding;
                    break;
            }

            return new Rectangle(x, y, imgSize.Width, imgSize.Height);
        }

        private Rectangle CalculateTextRectangle(ContentAlignment imageAlign, Size imgSize)
        {
            Rectangle textRect = new Rectangle(0, 0, this.Width, this.Height);

            // Adjust text rectangle based on image alignment
            if (this.Image != null)
            {
                switch (imageAlign)
                {
                    case ContentAlignment.TopLeft:
                    case ContentAlignment.TopCenter:
                    case ContentAlignment.TopRight:
                        // If image is at top, move text down but keep it centered horizontally
                        textRect.Y += imgSize.Height + _imagePadding;
                        textRect.Height -= imgSize.Height + _imagePadding;
                        break;

                    case ContentAlignment.MiddleLeft:
                        // If image is at left, move text right but keep it centered vertically
                        textRect.X += imgSize.Width + _imagePadding;
                        textRect.Width -= imgSize.Width + _imagePadding;
                        break;

                    case ContentAlignment.MiddleRight:
                        // If image is at right, reduce width but keep text at left
                        textRect.Width -= imgSize.Width + _imagePadding;
                        break;

                    case ContentAlignment.BottomLeft:
                    case ContentAlignment.BottomCenter:
                    case ContentAlignment.BottomRight:
                        // If image is at bottom, reduce height but keep text at top
                        textRect.Height -= imgSize.Height + _imagePadding;
                        break;
                }
            }

            return textRect;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Region = new Region(GetRoundedPath());
        }

        private GraphicsPath GetRoundedPath()
        {
            GraphicsPath path = new GraphicsPath();
            int radius = _cornerRadius;
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

            path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
            path.AddArc(rect.Width - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
            path.AddArc(rect.Width - radius * 2, rect.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(rect.X, rect.Height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseAllFigures();

            return path;
        }
    }
}