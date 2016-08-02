namespace EAExport.Windows
{
    internal static class Constants
    {
        #region TreeView Control
        public const int TVS_HASBUTTONS = 0x0001;
        public const int TVS_HASLINES = 0x0002;
        public const int TVS_LINESATROOT = 0x0004;
        public const int TVS_EDITLABELS = 0x0008;
        public const int TVS_DISABLEDRAGDROP = 0x0010;
        public const int TVS_SHOWSELALWAYS = 0x0020;
        public const int TVS_RTLREADING = 0x0040;
        public const int TVS_NOTOOLTIPS = 0x0080;
        public const int TVS_CHECKBOXES = 0x0100;
        public const int TVS_TRACKSELECT = 0x0200;
        public const int TVS_SINGLEEXPAND = 0x0400;
        public const int TVS_INFOTIP = 0x0800;
        public const int TVS_FULLROWSELECT = 0x1000;
        public const int TVS_NOSCROLL = 0x2000;
        public const int TVS_NONEVENHEIGHT = 0x4000;
        public const int TVS_NOHSCROLL = 0x8000;
        public const int TVS_EX_MULTISELECT = 0x0002;
        public const int TVS_EX_DOUBLEBUFFER = 0x0004;
        public const int TVS_EX_NOINDENTSTATE = 0x0008;
        public const int TVS_EX_RICHTOOLTIP = 0x0010;
        public const int TVS_EX_AUTOHSCROLL = 0x0020;
        public const int TVS_EX_FADEINOUTEXPANDOS = 0x0040;
        public const int TVS_EX_PARTIALCHECKBOXES = 0x0080;
        public const int TVS_EX_EXCLUSIONCHECKBOXES = 0x0100;
        public const int TVS_EX_DIMMEDCHECKBOXES = 0x0200;
        public const int TVS_EX_DRAWIMAGEASYNC = 0x0400;

        public const int TVGN_ROOT = 0x0000;
        public const int TVGN_NEXT = 0x0001;
        public const int TVGN_PREVIOUS = 0x0002;
        public const int TVGN_PARENT = 0x0003;
        public const int TVGN_CHILD = 0x0004;
        public const int TVGN_FIRSTVISIBLE = 0x0005;
        public const int TVGN_NEXTVISIBLE = 0x0006;
        public const int TVGN_PREVIOUSVISIBLE = 0x0007;
        public const int TVGN_DROPHILITE = 0x0008;
        public const int TVGN_CARET = 0x0009;
        public const int TVGN_LASTVISIBLE = 0x000A;
        public const int TVGN_NEXTSELECTED = 0x000B;
        #endregion

        #region Scrollbar
        public const int SB_LINEUP = 0;
        public const int SB_LINELEFT = 0;
        public const int SB_LINEDOWN = 1;
        public const int SB_LINERIGHT = 1;
        public const int SB_PAGEUP = 2;
        public const int SB_PAGELEFT = 2;
        public const int SB_PAGEDOWN = 3;
        public const int SB_PAGERIGHT = 3;
        public const int SB_THUMBPOSITION = 4;
        public const int SB_THUMBTRACK = 5;
        public const int SB_TOP = 6;
        public const int SB_LEFT = 6;
        public const int SB_BOTTOM = 7;
        public const int SB_RIGHT = 7;
        public const int SB_ENDSCROLL = 8;
        #endregion
    }
}
