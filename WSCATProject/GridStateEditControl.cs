using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;

namespace DataGridViewProcessEditTest
{
    ///<summary>
    /// GridStateEditControl
    ///</summary>
    [ToolboxItem(false)]
    public class GridStateEditControl : StateControl, IGridCellEditControl
    {
        #region Private variables

        private GridCell _Cell;
        private EditorPanel _EditorPanel;
        private Bitmap _EditorCellBitmap;

        private bool _ValueChanged;
        private bool _SuspendUpdate;

        private StretchBehavior _StretchBehavior = StretchBehavior.None;

        #endregion

        ///<summary>
        /// GridStateEditControl
        ///</summary>
        public GridStateEditControl()
        {
            StateChanged += ControlStateChanged;
        }

        #region ControlStateChanged

        /// <summary>
        /// Routine called when the control 'state' has changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlStateChanged(object sender, StateChangedEventArgs e)
        {
            if (_SuspendUpdate == false)
            {
                _Cell.Value = e.NewValue;

                _Cell.EditorValueChanged(this);
            }
        }

        #endregion

        #region OnInvalidated

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            base.OnInvalidated(e);

            if (_Cell != null && _SuspendUpdate == false)
                _Cell.InvalidateRender();
        }

        #endregion

        #region OnPaint

        protected override void OnPaint(PaintEventArgs e)
        {
            _Cell.PaintEditorBackground(e, this);

            base.OnPaint(e);
        }

        #endregion

        #region GetValue

        ///<summary>
        /// GetValue
        ///</summary>
        ///<param name="value"></param>
        ///<returns></returns>
        ///<exception cref="Exception"></exception>
        public virtual string GetValue(object value)
        {
            GridPanel panel = _Cell.GridPanel;

            if (value == null ||
                (panel.NullValue == NullValue.DBNull && value == DBNull.Value))
            {
                return ("");
            }

            return (Convert.ToString(value));
        }

        #endregion

        #region IGridCellEditControl Members

        #region Public properties

        #region CanInterrupt

        /// <summary>
        /// Gets whether the Grid can automatically interrupt the current
        /// NonModal cell edit operation when the mouse leaves the cell.
        /// 
        /// This is utilized in cases, such as the ButtonX editor, where
        /// multilevel controls may be involved.  In the ButtonX case this
        /// specifically enables the mouse to to leave the main cell window
        /// and not be interrupted by the grid until the current operation
        /// is complete by the editor itself.
        /// </summary>
        public bool CanInterrupt
        {
            get { return (true); }
        }

        #endregion

        #region CellEditMode

        /// <summary>
        /// Gets the cell editor activation mode. There are three modes
        /// available for choice, and their usage depends upon the desired
        /// editor presentation, as well as how well the given underlying
        /// control interacts with the grid control.
        /// </summary>
        public CellEditMode CellEditMode
        {
            // InPlace ?Edit operations occur 'in place', always live, always
            // in a state of interaction with the user. The CheckBoxEx, and
            // ButtonX editors are examples of this. 

            get { return (CellEditMode.InPlace); }
        }

        #endregion

        #region EditorCell

        /// <summary>
        /// Gets or sets the editor's current associated grid cell.
        /// </summary>
        public GridCell EditorCell
        {
            get { return (_Cell); }
            set { _Cell = value; }
        }

        #endregion

        #region EditorCellBitmap

        ///<summary>
        /// Gets or sets the editor's associated cell bitmap (internal use only).
        ///</summary>
        public Bitmap EditorCellBitmap
        {
            get { return (_EditorCellBitmap); }

            set
            {
                if (_EditorCellBitmap != null)
                    _EditorCellBitmap.Dispose();

                _EditorCellBitmap = value;
            }
        }

        #endregion

        #region EditorFormattedValue

        ///<summary>
        /// Gets the formatted editor value.
        ///</summary>
        public virtual string EditorFormattedValue
        {
            get { return (_Cell.Value.ToString()); }
        }

        #endregion

        #region EditorPanel

        /// <summary>
        /// Gets or sets the editor's associated cell panel (internal use only).
        /// </summary>
        public EditorPanel EditorPanel
        {
            get { return (_EditorPanel); }
            set { _EditorPanel = value; }
        }

        #endregion

        #region EditorValue

        /// <summary>
        /// Gets or sets the editor's value.
        /// </summary>
        public virtual object EditorValue
        {
            get { return (Value); }
            set { Value = GetValue(value); }
        }

        #endregion

        #region EditorValueChanged

        /// <summary>
        /// Gets or sets whether the editor value has changed.
        /// </summary>
        public virtual bool EditorValueChanged
        {
            get { return (_ValueChanged); }

            set
            {
                if (_ValueChanged != value)
                {
                    _ValueChanged = value;

                    // If the value is being marked as changed, then mark
                    // the editor session as 'dirty' as a feedback to the
                    // user of the intentional (or unintentional) change.

                    if (value == true)
                        _Cell.SetEditorDirty(this);
                }
            }
        }

        #endregion

        #region EditorValueType

        ///<summary>
        /// Gets the editor's default value data type.
        ///</summary>
        public virtual Type EditorValueType
        {
            get { return (typeof(string)); }
        }

        #endregion

        #region StretchBehavior

        /// <summary>
        /// Gets the editor's desired 'stretch' behavior.
        /// 
        /// The StretchBehavior defines whether the editor wants to
        /// automatically have it's size stretched to fill the given cell.
        /// 
        /// Editors, such as ButtonX, want to fill the cell horizontally
        /// and vertically, whereas other editors, such as the Slider,
        /// may only want to stretch horizontally (or potentially not at all). 
        /// </summary>
        public virtual StretchBehavior StretchBehavior
        {
            get { return (_StretchBehavior); }
            set { _StretchBehavior = value; }
        }

        #endregion

        #region SuspendUpdate

        /// <summary>
        /// Gets or sets whether updates to the grid
        /// state are (or should be) suspended.
        /// </summary>
        public bool SuspendUpdate
        {
            get { return (_SuspendUpdate); }
            set { _SuspendUpdate = value; }
        }

        #endregion

        #region ValueChangeBehavior

        /// <summary>
        /// Gets the behavior needed when a value changes in the editor.
        /// 
        /// For instance, CheckBoxEx Value changes require only the cell
        /// to be redisplayed with the new state, whereas editors such as
        /// the TextBoxX editor, may result in a new layout when the text changes.
        /// </summary>
        public virtual ValueChangeBehavior ValueChangeBehavior
        {
            get { return (ValueChangeBehavior.InvalidateLayout); }
        }

        #endregion

        #endregion

        #region InitializeContext

        ///<summary>
        /// Called to inform the editor it needs
        /// to initialize the its context environment.
        ///</summary>
        ///<param name="cell">Associated Cell</param>
        ///<param name="style">Effective cell style</param>
        public virtual void InitializeContext(GridCell cell, CellVisualStyle style)
        {
            _Cell = cell;

            Value = GetValue(_Cell.Value);
            Enabled = (_Cell.IsReadOnly == false);

            _ValueChanged = false;
        }

        #endregion

        #region GetProposedSize

        ///<summary>
        /// Called to retrieve the editors proposed size for the given
        /// cell, using the provided effective style and size constraint.
        ///</summary>
        ///<param name="g">Graphics object</param>
        ///<param name="cell">Associated Cell</param>
        ///<param name="style">Effective style</param>
        ///<param name="constraintSize">Constraining size</param>
        ///<returns>Proposed Size</returns>
        public virtual Size GetProposedSize(Graphics g,
            GridCell cell, CellVisualStyle style, Size constraintSize)
        {
            return (GetPreferredSize(constraintSize));
        }

        #endregion

        #region Edit support

        #region BeginEdit

        /// <summary>
        /// Called when a Modal cell edit is about to be initiated.
        /// </summary>
        /// <param name="selectAll">Signifies whether to select all
        /// editable content upon invocation.</param>
        /// <returns>The editor can cancel the edit
        /// operation by returning 'true' from this call</returns>
        public virtual bool BeginEdit(bool selectAll)
        {
            return (false);
        }

        #endregion

        #region EndEdit

        /// <summary>
        /// Called when the edit operation is about to end.
        /// </summary>
        /// <returns>The editor can cancel the end operation
        /// by returning 'true' from this call.</returns>
        public virtual bool EndEdit()
        {
            return (false);
        }

        #endregion

        #region CancelEdit

        /// <summary>
        /// Called when the edit operation is being cancelled.
        /// </summary>
        /// <returns>The editor can cancel the cancel operation
        /// by returning 'true' from this call.</returns>
        public virtual bool CancelEdit()
        {
            return (false);
        }

        #endregion

        #endregion

        #region CellRender

        /// Called to initiate the actual rendering of the editor
        /// value into the grid cell.  In most cases this can be (and is)
        /// handled by a simple call to EditorCell.CellRender(this, graphics).
        /// 
        /// If additional rendering is required by the editor, then the editor
        /// can completely render the cell contents itself (and never even call
        /// Editor.CellRender) or optionally perform additional rendering before
        /// or after the default cell rendering.
        public virtual void CellRender(Graphics g)
        {
            _Cell.CellRender(this, g);
        }

        #endregion

        #region Keyboard support

        #region CellKeyDown

        ///<summary>
        /// Called when a KeyDown occurs (not utilized when the
        /// CellEditMode is Modal)
        ///</summary>
        public virtual void CellKeyDown(KeyEventArgs e)
        {
            // If the user types a digit (0 - 9) then increment
            // the state color by 1 at that state offset

            if (e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9)
            {
                int index = e.KeyData - Keys.D0;
                string value = (string)EditorCell.Value;
                string[] s = value.Split(',');

                int k = Math.Max(index + 1, s.Length);

                int[] n = new int[k];

                for (int i = 0; i < k; i++)
                    n[i] = i < s.Length ? s[i][0] - '0' : 0;

                n[index] = (n[index] + 1) % 5;

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < k; i++)
                {
                    sb.Append(n[i]);
                    sb.Append(",");
                }

                sb.Length--;

                EditorCell.Value = sb.ToString();
            }
            else
            {
                OnKeyDown(e);
            }
        }

        #endregion

        #region WantsInputKey

        /// <summary>
        /// Called to determine if the editor
        /// wants to process and handle the given key.
        /// </summary>
        /// <param name="key">Key in question</param>
        /// <param name="gridWantsKey">true if editor wants to process the key</param>
        /// <returns></returns>
        public virtual bool WantsInputKey(Keys key, bool gridWantsKey)
        {
            // Lets handle all the digit keys

            if (key >= Keys.D0 && key <= Keys.D9)
                return (true);

            // And let the grid handle the rest

            return (gridWantsKey == false);
        }

        #endregion

        #endregion

        #region Mouse support

        #region OnCellMouseMove

        ///<summary>
        /// OnCellMouseMove
        ///</summary>
        ///<param name="e"></param>
        public virtual void OnCellMouseMove(MouseEventArgs e)
        {
            OnMouseMove(e);
        }

        #endregion

        #region OnCellMouseEnter

        ///<summary>
        /// OnCellMouseEnter
        ///</summary>
        ///<param name="e"></param>
        public virtual void OnCellMouseEnter(EventArgs e)
        {
            OnMouseEnter(e);
        }

        #endregion

        #region OnCellMouseLeave

        ///<summary>
        /// OnCellMouseLeave
        ///</summary>
        ///<param name="e"></param>
        public virtual void OnCellMouseLeave(EventArgs e)
        {
            OnMouseLeave(e);
        }

        #endregion

        #region OnCellMouseUp

        ///<summary>
        /// OnCellMouseUp
        ///</summary>
        ///<param name="e"></param>
        public virtual void OnCellMouseUp(MouseEventArgs e)
        {
            OnMouseUp(e);
        }

        #endregion

        #region OnCellMouseDown

        ///<summary>
        /// OnCellMouseDown
        ///</summary>
        ///<param name="e"></param>
        public virtual void OnCellMouseDown(MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        #endregion

        #endregion

        #endregion
    }
}
