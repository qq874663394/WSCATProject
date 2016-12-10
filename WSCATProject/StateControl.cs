using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewProcessEditTest
{
    public partial class StateControl : Control
    {
        #region Events

        #region StateChanged

        /// <summary>
        /// Occurs when the control state has changed
        /// </summary>
        [Description("Occurs when the control state has changed.")]
        public event EventHandler<StateChangedEventArgs> StateChanged;

        #endregion

        #endregion

        #region Private variables

        private MyState[] _States;

        private MyState _HitItem;
        private MyState _LastHitItem;
        private MyState _MouseDownItem;

        private string _Value;
        private bool _NeedRecalc;
        private Size _PreferredSize;

        #endregion

        public StateControl()
        {
            InitializeComponent();
        }

        #region Public properties

        #region Value

        /// <summary>
        /// Gets or sets the comma delimited state string.
        /// </summary>
        protected string Value
        {
            get
            {
                if (_Value == null)
                    _Value = GetStates();

                return (_Value);
            }

            set
            {
                if ((value != null && value.Equals(_Value) == false) ||
                    (value == null && value != _Value))
                {
                    _Value = value;

                    SetStates(value);
                }
            }
        }

        #region GetStates

        /// <summary>
        /// Gets the states "string" value.
        /// </summary>
        /// <returns></returns>
        private string GetStates()
        {
            StringBuilder sb = new StringBuilder();

            if (_States != null)
            {
                foreach (MyState state in _States)
                {
                    sb.Append(state.ColorIndex);
                    sb.Append(",");
                }

                if (sb.Length > 0)
                    sb.Length--;
            }

            return (sb.ToString());
        }

        #endregion

        #region SetStates

        /// <summary>
        /// Sets the states "string" value
        /// </summary>
        /// <param name="value"></param>
        private void SetStates(string value)
        {
            if (value == null)
            {
                _States = null;
            }
            else
            {
                string[] states = value.Split(',');
                
                _States = new MyState[states.Length];

                int i = 0;
                foreach (string s in states)
                {
                    int n;
                    int.TryParse(s, out n);

                    _States[i++] = new MyState(n);
                }
            }

            _NeedRecalc = true;
        }

        #endregion

        #endregion

        #endregion

        #region OnPaint

        /// <summary>
        /// Handles paint event requests
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (_States != null)
            {
                if (_NeedRecalc == true)
                    RecalcLayout();

                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                foreach (MyState state in _States)
                {
                    Rectangle r = state.Bounds;

                    if (_HitItem == state)
                        r.Inflate(1, 1);

                    int index = state.ColorIndex;

                    if ((uint) index >= imageList1.Images.Count)
                        index = 0;

                    g.DrawImageUnscaledAndClipped(imageList1.Images[index], r);
                }
            }
        }

        #endregion

        #region RecalcLayout

        /// <summary>
        /// Recalculates the states layout
        /// </summary>
        private void RecalcLayout()
        {
            _PreferredSize = Bounds.Size;

            if (_States != null)
            {
                Rectangle r = Bounds;
                r.Inflate(-2, -2);
                r.Width = 16;

                r.Y += (r.Height - 16)/2;
                r.Height = 16;

                foreach (MyState state in _States)
                {
                    state.Bounds = r;

                    r.X += 18;
                }

                _PreferredSize.Width = r.X - Bounds.X;
            }

            _NeedRecalc = false;
        }

        #endregion

        #region GetPreferredSize

        /// <summary>
        /// Gets the control's preferred size
        /// </summary>
        /// <param name="proposedSize"></param>
        /// <returns></returns>
        public override Size GetPreferredSize(Size proposedSize)
        {
            if (_NeedRecalc == true)
                RecalcLayout();

            return (_PreferredSize);
        }

        #endregion

        #region Mouse support

        #region OnMouseMove

        /// <summary>
        /// Handles MouseMove events
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            _HitItem = GetHitItem(e.Location);

            if (_HitItem != _LastHitItem)
            {
                _LastHitItem = _HitItem;

                Invalidate();
            }
        }

        #region GetHitItem

        /// <summary>
        /// Gets the item currently under the mouse
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        private MyState GetHitItem(Point pt)
        {
            if (_States != null)
            {
                foreach (MyState state in _States)
                {
                    if (state.Bounds.Contains(pt) == true)
                        return (state);
                }
            }

            return (null);
        }
        ToolTip tt = new ToolTip();
        #endregion

        #endregion

        #region OnMouseDown

        /// <summary>
        /// Handles MouseDown events
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            _MouseDownItem = _HitItem;
        }

        #endregion

        #region OnMouseUp

        /// <summary>
        /// Handles MouseUp events
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            // Change the state colorIndex
            // if the user clicked on an item.

            //if (_MouseDownItem != null && _MouseDownItem == _HitItem)
            //{
            //    _MouseDownItem.ColorIndex =
            //        (_MouseDownItem.ColorIndex + 1) % imageList1.Images.Count;

            //    OnValueChanged();
            //}

            //_MouseDownItem = null;

            //base.OnMouseUp(e);
        }

        #region OnValueChanged

        /// <summary>
        /// OnValueChanged
        /// </summary>
        private void OnValueChanged()
        {
            string oldValue = Value;

            _Value = null;

            if (StateChanged != null)
                StateChanged(this, new StateChangedEventArgs(oldValue, Value));
        }

        #endregion

        #endregion

        #endregion
    }

    #region StateChangedEventArgs

    /// <summary>
    /// StateChangedEventArgs
    /// </summary>
    public class StateChangedEventArgs : EventArgs
    {
        #region Private variables

        private string _OldValue;
        private string _NewValue;

        #endregion

        ///<summary>
        /// StateChangedEventArgs
        ///</summary>
        ///<param name="oldValue"></param>
        ///<param name="newValue"></param>
        public StateChangedEventArgs(string oldValue, string newValue)
        {
            _OldValue = oldValue;
            _NewValue = newValue;
        }

        #region Public properties

        /// <summary>
        /// Gets the old value
        /// </summary>
        public string OldValue
        {
            get { return (_OldValue); }
        }

        /// <summary>
        /// Gets the new value
        /// </summary>
        public string NewValue
        {
            get { return (_NewValue); }
        }

        #endregion
    }

    #endregion

    #region MyState

    public class MyState
    {
        #region Private variables

        private int _ColorIndex;
        private Rectangle _Bounds;

        #endregion

        public MyState(int colorIndex)
        {
            _ColorIndex = colorIndex;
        }

        #region Public properties

        #region Bounds

        /// <summary>
        /// Gets the state bounding rect
        /// </summary>
        public Rectangle Bounds
        {
            get { return (_Bounds); }
            internal set { _Bounds = value; }
        }

        #endregion

        #region ColorIndex

        /// <summary>
        /// Gets or sets the state color index
        /// </summary>
        public int ColorIndex
        {
            get { return (_ColorIndex); }
            set { _ColorIndex = value; }
        }

        #endregion

        #endregion
    }

    #endregion
}
