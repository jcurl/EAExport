namespace EAExport.Windows
{
    using System;

    internal static class Msg
    {
        [Flags]
        private enum WM_TVM
        {
            TVM_INSERTITEMA = 0x1100,
            TVM_INSERTITEMW = 0x1132,
            TVM_INSERTITEM = TVM_INSERTITEMW,
            TVM_DELETEITEM = 0x1101,
            TVM_EXPAND = 0x1102,
            TVM_GETITEMRECT = 0x1104,
            TVM_GETCOUNT = 0x1105,
            TVM_GETINDENT = 0x1106,
            TVM_SETINDENT = 0x1107,
            TVM_GETIMAGELIST = 0x1108,
            TVM_SETIMAGELIST = 0x1109,
            TVM_GETNEXTITEM = 0x110A,
            TVM_SELECTITEM = 0x110B,
            TVM_GETITEMA = 0x110C,
            TVM_GETITEMW = 0x113E,
            TVM_GETITEM = TVM_GETITEMW,
            TVM_SETITEMA = 0x110D,
            TVM_SETITEMW = 0x113F,
            TVM_SETITEM = TVM_SETITEMW,
            TVM_EDITLABELA = 0x110E,
            TVM_EDITLABELW = 0x1141,
            TVM_EDITLABEL = TVM_EDITLABELW,
            TVM_GETEDITCONTROL = 0x110F,
            TVM_GETVISIBLECOUNT = 0x1110,
            TVM_HITTEST = 0x1111,
            TVM_CREATEDRAGIMAGE = 0x1112,
            TVM_SORTCHILDREN = 0x1113,
            TVM_ENSUREVISIBLE = 0x1114,
            TVM_SORTCHILDRENCB = 0x1115,
            TVM_ENDEDITLABELNOW = 0x1116,
            TVM_GETISEARCHSTRINGA = 0x1117,
            TVM_GETISEARCHSTRINGW = 0x1140,
            TVM_GETISEARCHSTRING = TVM_GETISEARCHSTRINGW,
            TVM_SETTOOLTIPS = 0x1118,
            TVM_GETTOOLTIPS = 0x1119,
            TVM_SETINSERTMARK = 0x111A,
            TVM_SETUNICODEFORMAT = 0x2005,
            TVM_GETUNICODEFORMAT = 0x2006,
            TVM_SETITEMHEIGHT = 0x111B,
            TVM_GETITEMHEIGHT = 0x111C,
            TVM_SETBKCOLOR = 0x111D,
            TVM_SETTEXTCOLOR = 0x111E,
            TVM_GETBKCOLOR = 0x111F,
            TVM_GETTEXTCOLOR = 0x1120,
            TVM_SETSCROLLTIME = 0x1121,
            TVM_GETSCROLLTIME = 0x1122,
            TVM_SETINSERTMARKCOLOR = 0x1125,
            TVM_GETINSERTMARKCOLOR = 0x1126,
            TVM_GETITEMSTATE = 0x1127,
            TVM_SETLINECOLOR = 0x1128,
            TVM_GETLINECOLOR = 0x1129,
            TVM_MAPACCIDTOHTREEITEM = 0x112A,
            TVM_MAPHTREEITEMTOACCID = 0x112B,
            TVM_SETEXTENDEDSTYLE = 0x112C,     // Windows Vista
            TVM_GETEXTENDEDSTYLE = 0x112D,
            TVM_SETAUTOSCROLLINFO = 0x113B,
            TVM_GETSELECTEDCOUNT = 0x1146,
            TVM_SHOWINFOTIP = 0x1147,
            TVM_GETITEMPARTRECT = 0x1148
        }

        // The enum's are used to print the names of the constants in the
        // ToString() method. Otherwise they wouldn't be needed.
        [Flags]
        private enum WM_Std
        {
            WM_NULL = 0x0000,
            WM_CREATE = 0x0001,
            WM_DESTROY = 0x0002,
            WM_MOVE = 0x0003,
            WM_SIZE = 0x0005,
            WM_ACTIVATE = 0x0006,
            WM_SETFOCUS = 0x0007,
            WM_KILLFOCUS = 0x0008,
            WM_ENABLE = 0x000A,
            WM_SETREDRAW = 0x000B,
            WM_SETTEXT = 0x000C,
            WM_GETTEXT = 0x000D,
            WM_GETTEXTLENGTH = 0x000E,
            WM_PAINT = 0x000F,
            WM_CLOSE = 0x0010,
            WM_QUERYENDSESSION = 0x0011,
            WM_QUERYOPEN = 0x0013,
            WM_ENDSESSION = 0x0016,
            WM_QUIT = 0x0012,
            WM_ERASEBKGND = 0x0014,
            WM_SYSCOLORCHANGE = 0x0015,
            WM_SHOWWINDOW = 0x0018,
            WM_WININICHANGE = 0x001A,
            WM_SETTINGCHANGE = WM_Std.WM_WININICHANGE,
            WM_DEVMODECHANGE = 0x001B,
            WM_ACTIVATEAPP = 0x001C,
            WM_FONTCHANGE = 0x001D,
            WM_TIMECHANGE = 0x001E,
            WM_CANCELMODE = 0x001F,
            WM_SETCURSOR = 0x0020,
            WM_MOUSEACTIVATE = 0x0021,
            WM_CHILDACTIVATE = 0x0022,
            WM_QUEUESYNC = 0x0023,
            WM_GETMINMAXINFO = 0x0024,
            WM_PAINTICON = 0x0026,
            WM_ICONERASEBKGND = 0x0027,
            WM_NEXTDLGCTL = 0x0028,
            WM_SPOOLERSTATUS = 0x002A,
            WM_DRAWITEM = 0x002B,
            WM_MEASUREITEM = 0x002C,
            WM_DELETEITEM = 0x002D,
            WM_VKEYTOITEM = 0x002E,
            WM_CHARTOITEM = 0x002F,
            WM_SETFONT = 0x0030,
            WM_GETFONT = 0x0031,
            WM_SETHOTKEY = 0x0032,
            WM_GETHOTKEY = 0x0033,
            WM_QUERYDRAGICON = 0x0037,
            WM_COMPAREITEM = 0x0039,
            WM_GETOBJECT = 0x003D,
            WM_COMPACTING = 0x0041,
            [Obsolete]
            WM_COMMNOTIFY = 0x0044,
            WM_WINDOWPOSCHANGING = 0x0046,
            WM_WINDOWPOSCHANGED = 0x0047,
            [Obsolete]
            WM_POWER = 0x0048,
            WM_COPYDATA = 0x004A,
            WM_CANCELJOURNAL = 0x004B,
            WM_NOTIFY = 0x004E,
            WM_INPUTLANGCHANGEREQUEST = 0x0050,
            WM_INPUTLANGCHANGE = 0x0051,
            WM_TCARD = 0x0052,
            WM_HELP = 0x0053,
            WM_USERCHANGED = 0x0054,
            WM_NOTIFYFORMAT = 0x0055,
            WM_CONTEXTMENU = 0x007B,
            WM_STYLECHANGING = 0x007C,
            WM_STYLECHANGED = 0x007D,
            WM_DISPLAYCHANGE = 0x007E,
            WM_GETICON = 0x007F,
            WM_SETICON = 0x0080,
            WM_NCCREATE = 0x0081,
            WM_NCDESTROY = 0x0082,
            WM_NCCALCSIZE = 0x0083,
            WM_NCHITTEST = 0x0084,
            WM_NCPAINT = 0x0085,
            WM_NCACTIVATE = 0x0086,
            WM_GETDLGCODE = 0x0087,
            WM_SYNCPAINT = 0x0088,
            WM_NCMOUSEMOVE = 0x00A0,
            WM_NCLBUTTONDOWN = 0x00A1,
            WM_NCLBUTTONUP = 0x00A2,
            WM_NCLBUTTONDBLCLK = 0x00A3,
            WM_NCRBUTTONDOWN = 0x00A4,
            WM_NCRBUTTONUP = 0x00A5,
            WM_NCRBUTTONDBLCLK = 0x00A6,
            WM_NCMBUTTONDOWN = 0x00A7,
            WM_NCMBUTTONUP = 0x00A8,
            WM_NCMBUTTONDBLCLK = 0x00A9,
            WM_NCXBUTTONDOWN = 0x00AB,
            WM_NCXBUTTONUP = 0x00AC,
            WM_NCXBUTTONDBLCLK = 0x00AD,
            WM_INPUT_DEVICE_CHANGE = 0x00FE,
            WM_INPUT = 0x00FF,
            WM_KEYDOWN = 0x0100,
            WM_KEYFIRST = 0x0100,              // Move this after, so ToString() finds KeyDown
            WM_KEYUP = 0x0101,
            WM_CHAR = 0x0102,
            WM_DEADCHAR = 0x0103,
            WM_SYSKEYDOWN = 0x0104,
            WM_SYSKEYUP = 0x0105,
            WM_SYSCHAR = 0x0106,
            WM_SYSDEADCHAR = 0x0107,
            WM_UNICHAR = 0x0109,
            WM_KEYLAST = 0x0109,
            WM_IME_STARTCOMPOSITION = 0x010D,
            WM_IME_ENDCOMPOSITION = 0x010E,
            WM_IME_COMPOSITION = 0x010F,
            WM_IME_KEYLAST = 0x010F,
            WM_INITDIALOG = 0x0110,
            WM_COMMAND = 0x0111,
            WM_SYSCOMMAND = 0x0112,
            WM_TIMER = 0x0113,
            WM_HSCROLL = 0x0114,
            WM_VSCROLL = 0x0115,
            WM_INITMENU = 0x0116,
            WM_INITMENUPOPUP = 0x0117,
            WM_SYSTIMER = 0x118,
            WM_MENUSELECT = 0x011F,
            WM_MENUCHAR = 0x0120,
            WM_ENTERIDLE = 0x0121,
            WM_MENURBUTTONUP = 0x0122,
            WM_MENUDRAG = 0x0123,
            WM_MENUGETOBJECT = 0x0124,
            WM_UNINITMENUPOPUP = 0x0125,
            WM_MENUCOMMAND = 0x0126,
            WM_CHANGEUISTATE = 0x0127,
            WM_UPDATEUISTATE = 0x0128,
            WM_QUERYUISTATE = 0x0129,
            WM_CTLCOLORMSGBOX = 0x0132,
            WM_CTLCOLOREDIT = 0x0133,
            WM_CTLCOLORLISTBOX = 0x0134,
            WM_CTLCOLORBTN = 0x0135,
            WM_CTLCOLORDLG = 0x0136,
            WM_CTLCOLORSCROLLBAR = 0x0137,
            WM_CTLCOLORSTATIC = 0x0138,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEFIRST = 0x0200,            // Move this after, so ToString() finds MouseMove
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_LBUTTONDBLCLK = 0x0203,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205,
            WM_RBUTTONDBLCLK = 0x0206,
            WM_MBUTTONDOWN = 0x0207,
            WM_MBUTTONUP = 0x0208,
            WM_MBUTTONDBLCLK = 0x0209,
            WM_MOUSEWHEEL = 0x020A,
            WM_XBUTTONDOWN = 0x020B,
            WM_XBUTTONUP = 0x020C,
            WM_XBUTTONDBLCLK = 0x020D,
            WM_MOUSEHWHEEL = 0x020E,
            WM_MOUSELAST = 0x020E,
            WM_PARENTNOTIFY = 0x0210,
            WM_ENTERMENULOOP = 0x0211,
            WM_EXITMENULOOP = 0x0212,
            WM_NEXTMENU = 0x0213,
            WM_SIZING = 0x0214,
            WM_CAPTURECHANGED = 0x0215,
            WM_MOVING = 0x0216,
            WM_POWERBROADCAST = 0x0218,
            WM_DEVICECHANGE = 0x0219,
            WM_MDICREATE = 0x0220,
            WM_MDIDESTROY = 0x0221,
            WM_MDIACTIVATE = 0x0222,
            WM_MDIRESTORE = 0x0223,
            WM_MDINEXT = 0x0224,
            WM_MDIMAXIMIZE = 0x0225,
            WM_MDITILE = 0x0226,
            WM_MDICASCADE = 0x0227,
            WM_MDIICONARRANGE = 0x0228,
            WM_MDIGETACTIVE = 0x0229,
            WM_MDISETMENU = 0x0230,
            WM_ENTERSIZEMOVE = 0x0231,
            WM_EXITSIZEMOVE = 0x0232,
            WM_DROPFILES = 0x0233,
            WM_MDIREFRESHMENU = 0x0234,
            WM_IME_SETCONTEXT = 0x0281,
            WM_IME_NOTIFY = 0x0282,
            WM_IME_CONTROL = 0x0283,
            WM_IME_COMPOSITIONFULL = 0x0284,
            WM_IME_SELECT = 0x0285,
            WM_IME_CHAR = 0x0286,
            WM_IME_REQUEST = 0x0288,
            WM_IME_KEYDOWN = 0x0290,
            WM_IME_KEYUP = 0x0291,
            WM_MOUSEHOVER = 0x02A1,
            WM_MOUSELEAVE = 0x02A3,
            WM_NCMOUSEHOVER = 0x02A0,
            WM_NCMOUSELEAVE = 0x02A2,
            WM_WTSSESSION_CHANGE = 0x02B1,
            WM_TABLET_FIRST = 0x02c0,
            WM_TABLET_LAST = 0x02df,
            WM_CUT = 0x0300,
            WM_COPY = 0x0301,
            WM_PASTE = 0x0302,
            WM_CLEAR = 0x0303,
            WM_UNDO = 0x0304,
            WM_RENDERFORMAT = 0x0305,
            WM_RENDERALLFORMATS = 0x0306,
            WM_DESTROYCLIPBOARD = 0x0307,
            WM_DRAWCLIPBOARD = 0x0308,
            WM_PAINTCLIPBOARD = 0x0309,
            WM_VSCROLLCLIPBOARD = 0x030A,
            WM_SIZECLIPBOARD = 0x030B,
            WM_ASKCBFORMATNAME = 0x030C,
            WM_CHANGECBCHAIN = 0x030D,
            WM_HSCROLLCLIPBOARD = 0x030E,
            WM_QUERYNEWPALETTE = 0x030F,
            WM_PALETTEISCHANGING = 0x0310,
            WM_PALETTECHANGED = 0x0311,
            WM_HOTKEY = 0x0312,
            WM_PRINT = 0x0317,
            WM_PRINTCLIENT = 0x0318,
            WM_APPCOMMAND = 0x0319,
            WM_THEMECHANGED = 0x031A,
            WM_CLIPBOARDUPDATE = 0x031D,
            WM_DWMCOMPOSITIONCHANGED = 0x031E,
            WM_DWMNCRENDERINGCHANGED = 0x031F,
            WM_DWMCOLORIZATIONCOLORCHANGED = 0x0320,
            WM_DWMWINDOWMAXIMIZEDCHANGE = 0x0321,
            WM_GETTITLEBARINFOEX = 0x033F,
            WM_HANDHELDFIRST = 0x0358,
            WM_HANDHELDLAST = 0x035F,
            WM_AFXFIRST = 0x0360,
            WM_AFXLAST = 0x037F,
            WM_PENWINFIRST = 0x0380,
            WM_PENWINLAST = 0x038F,

            WM_USER = 0x0400,
            WM_REFLECT = WM_USER + 0x1c00,
            WM_APP = 0x8000,

            CPL_LAUNCH = WM_USER + 0x1000,
            CPL_LAUNCHED = WM_USER + 0x1001,
        }

        #region TVM_CONSTANTS
        public const int TVM_INSERTITEMA = (int)WM_TVM.TVM_INSERTITEMA;
        public const int TVM_INSERTITEMW = (int)WM_TVM.TVM_INSERTITEMW;
        public const int TVM_INSERTITEM = (int)WM_TVM.TVM_INSERTITEM;
        public const int TVM_DELETEITEM = (int)WM_TVM.TVM_DELETEITEM;
        public const int TVM_EXPAND = (int)WM_TVM.TVM_EXPAND;
        public const int TVM_GETITEMRECT = (int)WM_TVM.TVM_GETITEMRECT;
        public const int TVM_GETCOUNT = (int)WM_TVM.TVM_GETCOUNT;
        public const int TVM_GETINDENT = (int)WM_TVM.TVM_GETINDENT;
        public const int TVM_SETINDENT = (int)WM_TVM.TVM_SETINDENT;
        public const int TVM_GETIMAGELIST = (int)WM_TVM.TVM_GETIMAGELIST;
        public const int TVM_SETIMAGELIST = (int)WM_TVM.TVM_SETIMAGELIST;
        public const int TVM_GETNEXTITEM = (int)WM_TVM.TVM_GETNEXTITEM;
        public const int TVM_SELECTITEM = (int)WM_TVM.TVM_SELECTITEM;
        public const int TVM_GETITEMA = (int)WM_TVM.TVM_GETITEMA;
        public const int TVM_GETITEMW = (int)WM_TVM.TVM_GETITEMW;
        public const int TVM_GETITEM = (int)WM_TVM.TVM_GETITEM;
        public const int TVM_SETITEMA = (int)WM_TVM.TVM_SETITEMA;
        public const int TVM_SETITEMW = (int)WM_TVM.TVM_SETITEMW;
        public const int TVM_SETITEM = (int)WM_TVM.TVM_SETITEM;
        public const int TVM_EDITLABELA = (int)WM_TVM.TVM_EDITLABELA;
        public const int TVM_EDITLABELW = (int)WM_TVM.TVM_EDITLABELW;
        public const int TVM_EDITLABEL = (int)WM_TVM.TVM_EDITLABEL;
        public const int TVM_GETEDITCONTROL = (int)WM_TVM.TVM_GETEDITCONTROL;
        public const int TVM_GETVISIBLECOUNT = (int)WM_TVM.TVM_GETVISIBLECOUNT;
        public const int TVM_HITTEST = (int)WM_TVM.TVM_HITTEST;
        public const int TVM_CREATEDRAGIMAGE = (int)WM_TVM.TVM_CREATEDRAGIMAGE;
        public const int TVM_SORTCHILDREN = (int)WM_TVM.TVM_SORTCHILDREN;
        public const int TVM_ENSUREVISIBLE = (int)WM_TVM.TVM_ENSUREVISIBLE;
        public const int TVM_SORTCHILDRENCB = (int)WM_TVM.TVM_SORTCHILDRENCB;
        public const int TVM_ENDEDITLABELNOW = (int)WM_TVM.TVM_ENDEDITLABELNOW;
        public const int TVM_GETISEARCHSTRINGA = (int)WM_TVM.TVM_GETISEARCHSTRINGA;
        public const int TVM_GETISEARCHSTRINGW = (int)WM_TVM.TVM_GETISEARCHSTRINGW;
        public const int TVM_GETISEARCHSTRING = (int)WM_TVM.TVM_GETISEARCHSTRING;
        public const int TVM_SETTOOLTIPS = (int)WM_TVM.TVM_SETTOOLTIPS;
        public const int TVM_GETTOOLTIPS = (int)WM_TVM.TVM_GETTOOLTIPS;
        public const int TVM_SETINSERTMARK = (int)WM_TVM.TVM_SETINSERTMARK;
        public const int TVM_SETUNICODEFORMAT = (int)WM_TVM.TVM_SETUNICODEFORMAT;
        public const int TVM_GETUNICODEFORMAT = (int)WM_TVM.TVM_GETUNICODEFORMAT;
        public const int TVM_SETITEMHEIGHT = (int)WM_TVM.TVM_SETITEMHEIGHT;
        public const int TVM_GETITEMHEIGHT = (int)WM_TVM.TVM_GETITEMHEIGHT;
        public const int TVM_SETBKCOLOR = (int)WM_TVM.TVM_SETBKCOLOR;
        public const int TVM_SETTEXTCOLOR = (int)WM_TVM.TVM_SETTEXTCOLOR;
        public const int TVM_GETBKCOLOR = (int)WM_TVM.TVM_GETBKCOLOR;
        public const int TVM_GETTEXTCOLOR = (int)WM_TVM.TVM_GETTEXTCOLOR;
        public const int TVM_SETSCROLLTIME = (int)WM_TVM.TVM_SETSCROLLTIME;
        public const int TVM_GETSCROLLTIME = (int)WM_TVM.TVM_GETSCROLLTIME;
        public const int TVM_SETINSERTMARKCOLOR = (int)WM_TVM.TVM_SETINSERTMARKCOLOR;
        public const int TVM_GETINSERTMARKCOLOR = (int)WM_TVM.TVM_GETINSERTMARKCOLOR;
        public const int TVM_GETITEMSTATE = (int)WM_TVM.TVM_GETITEMSTATE;
        public const int TVM_SETLINECOLOR = (int)WM_TVM.TVM_SETLINECOLOR;
        public const int TVM_GETLINECOLOR = (int)WM_TVM.TVM_GETLINECOLOR;
        public const int TVM_MAPACCIDTOHTREEITEM = (int)WM_TVM.TVM_MAPACCIDTOHTREEITEM;
        public const int TVM_MAPHTREEITEMTOACCID = (int)WM_TVM.TVM_MAPHTREEITEMTOACCID;
        public const int TVM_SETEXTENDEDSTYLE = (int)WM_TVM.TVM_SETEXTENDEDSTYLE;
        public const int TVM_GETEXTENDEDSTYLE = (int)WM_TVM.TVM_GETEXTENDEDSTYLE;
        public const int TVM_SETAUTOSCROLLINFO = (int)WM_TVM.TVM_SETAUTOSCROLLINFO;
        public const int TVM_GETSELECTEDCOUNT = (int)WM_TVM.TVM_GETSELECTEDCOUNT;
        public const int TVM_SHOWINFOTIP = (int)WM_TVM.TVM_SHOWINFOTIP;
        public const int TVM_GETITEMPARTRECT = (int)WM_TVM.TVM_GETITEMPARTRECT;
        #endregion

        #region WM_CONSTANTS
        /// <summary>
        /// The WM_NULL message performs no operation. An application sends 
        /// the WM_NULL message if it wants to post a message that the 
        /// recipient window will ignore.
        /// </summary>
        public const int WM_NULL = (int)WM_Std.WM_NULL;
        /// <summary>
        /// The WM_CREATE message is sent when an application requests that 
        /// a window be created by calling the CreateWindowEx or 
        /// CreateWindow function. (The message is sent before the function 
        /// returns.) The window procedure of the new window receives this 
        /// message after the window is created, but before the window 
        /// becomes visible.
        /// </summary>
        public const int WM_CREATE = (int)WM_Std.WM_CREATE;
        /// <summary>
        /// The WM_DESTROY message is sent when a window is being destroyed. 
        /// It is sent to the window procedure of the window being destroyed 
        /// after the window is removed from the screen. 
        /// This message is sent first to the window being destroyed and then
        /// to the child windows (if any) as they are destroyed. During the 
        /// processing of the message, it can be assumed that all child 
        /// windows still exist.
        /// /// </summary>
        public const int WM_DESTROY = (int)WM_Std.WM_DESTROY;
        /// <summary>
        /// The WM_MOVE message is sent after a window has been moved. 
        /// </summary>
        public const int WM_MOVE = (int)WM_Std.WM_MOVE;
        /// <summary>
        /// The WM_SIZE message is sent to a window after its size has 
        /// changed.
        /// </summary>
        public const int WM_SIZE = (int)WM_Std.WM_SIZE;
        /// <summary>
        /// The WM_ACTIVATE message is sent to both the window being 
        /// activated and the window being deactivated. If the windows use 
        /// the same input queue, the message is sent synchronously, first 
        /// to the window procedure of the top-level window being
        /// deactivated, then to the window procedure of the top-level 
        /// window being activated. If the windows use different input 
        /// queues, the message is sent asynchronously, so the window is 
        /// activated immediately. 
        /// </summary>
        public const int WM_ACTIVATE = (int)WM_Std.WM_ACTIVATE;
        /// <summary>
        /// The WM_SETFOCUS message is sent to a window after it has gained 
        /// the keyboard focus. 
        /// </summary>
        public const int WM_SETFOCUS = (int)WM_Std.WM_SETFOCUS;
        /// <summary>
        /// The WM_KILLFOCUS message is sent to a window immediately before 
        /// it loses the keyboard focus. 
        /// </summary>
        public const int WM_KILLFOCUS = (int)WM_Std.WM_KILLFOCUS;
        /// <summary>
        /// The WM_ENABLE message is sent when an application changes the
        /// enabled state of a window. It is sent to the window whose enabled
        /// state is changing. This message is sent before the EnableWindow 
        /// function returns, but after the enabled state (WS_DISABLED style
        /// bit) of the window has changed. 
        /// </summary>
        public const int WM_ENABLE = (int)WM_Std.WM_ENABLE;
        /// <summary>
        /// An application sends the WM_SETREDRAW message to a window to 
        /// allow changes in that window to be redrawn or to prevent changes
        /// in that window from being redrawn. 
        /// </summary>
        public const int WM_SETREDRAW = (int)WM_Std.WM_SETREDRAW;
        /// <summary>
        /// An application sends a WM_SETTEXT message to set the text of a
        /// window. 
        /// </summary>
        public const int WM_SETTEXT = (int)WM_Std.WM_SETTEXT;
        /// <summary>
        /// An application sends a WM_GETTEXT message to copy the text that
        /// corresponds to a window into a buffer provided by the caller. 
        /// </summary>
        public const int WM_GETTEXT = (int)WM_Std.WM_GETTEXT;
        /// <summary>
        /// An application sends a WM_GETTEXTLENGTH message to determine the
        /// length, in characters, of the text associated with a window. 
        /// </summary>
        public const int WM_GETTEXTLENGTH = (int)WM_Std.WM_GETTEXTLENGTH;
        /// <summary>
        /// The WM_PAINT message is sent when the system or another
        /// application makes a request to paint a portion of an
        /// application's window. The message is sent when the UpdateWindow
        /// or RedrawWindow function is called, or by the DispatchMessage
        /// function when the application obtains a WM_PAINT message by
        /// using the GetMessage or PeekMessage function. 
        /// </summary>
        public const int WM_PAINT = (int)WM_Std.WM_PAINT;
        /// <summary>
        /// The WM_CLOSE message is sent as a signal that a window or an
        /// application should terminate.
        /// </summary>
        public const int WM_CLOSE = (int)WM_Std.WM_CLOSE;
        /// <summary>
        /// The WM_QUERYENDSESSION message is sent when the user chooses to
        /// end the session or when an application calls one of the system
        /// shutdown functions. If any application returns zero, the session
        /// is not ended. The system stops sending WM_QUERYENDSESSION
        /// messages as soon as one application returns zero.
        /// After processing this message, the system sends the
        /// WM_ENDSESSION message with the wParam parameter set to the
        /// results of the WM_QUERYENDSESSION message.
        /// </summary>
        public const int WM_QUERYENDSESSION = (int)WM_Std.WM_QUERYENDSESSION;
        /// <summary>
        /// The WM_QUERYOPEN message is sent to an icon when the user
        /// requests that the window be restored to its previous size and
        /// position.
        /// </summary>
        public const int WM_QUERYOPEN = (int)WM_Std.WM_QUERYOPEN;
        /// <summary>
        /// The WM_ENDSESSION message is sent to an application after the
        /// system processes the results of the WM_QUERYENDSESSION message.
        /// The WM_ENDSESSION message informs the application whether the
        /// session is ending.
        /// </summary>
        public const int WM_ENDSESSION = (int)WM_Std.WM_ENDSESSION;
        /// <summary>
        /// The WM_QUIT message indicates a request to terminate an
        /// application and is generated when the application calls the
        /// PostQuitMessage function. It causes the GetMessage function to
        /// return zero.
        /// </summary>
        public const int WM_QUIT = (int)WM_Std.WM_QUIT;
        /// <summary>
        /// The WM_ERASEBKGND message is sent when the window background must
        /// be erased (for example, when a window is resized). The message is
        /// sent to prepare an invalidated portion of a window for painting.
        /// </summary>
        public const int WM_ERASEBKGND = (int)WM_Std.WM_ERASEBKGND;
        /// <summary>
        /// This message is sent to all top-level windows when a change is
        /// made to a system color setting. 
        /// </summary>
        public const int WM_SYSCOLORCHANGE = (int)WM_Std.WM_SYSCOLORCHANGE;
        /// <summary>
        /// The WM_SHOWWINDOW message is sent to a window when the window is
        /// about to be hidden or shown.
        /// </summary>
        public const int WM_SHOWWINDOW = (int)WM_Std.WM_SHOWWINDOW;
        /// <summary>
        /// An application sends the WM_WININICHANGE message to all top-level
        /// windows after making a change to the WIN.INI file. The 
        /// SystemParametersInfo function sends this message after an 
        /// application uses the function to change a setting in WIN.INI.
        /// Note:  The WM_WININICHANGE message is provided only for 
        /// compatibility with earlier versions of the system. Applications
        /// should use the WM_SETTINGCHANGE message.
        /// </summary>
        public const int WM_WININICHANGE = (int)WM_Std.WM_WININICHANGE;
        /// <summary>
        /// An application sends the WM_WININICHANGE message to all top-level
        /// windows after making a change to the WIN.INI file. The
        /// SystemParametersInfo function sends this message after an
        /// application uses the function to change a setting in WIN.INI.
        /// Note  The WM_WININICHANGE message is provided only for
        /// compatibility with earlier versions of the system. Applications
        /// should use the WM_SETTINGCHANGE message.
        /// </summary>
        public const int WM_SETTINGCHANGE = (int)WM_Std.WM_SETTINGCHANGE;
        /// <summary>
        /// The WM_DEVMODECHANGE message is sent to all top-level windows
        /// whenever the user changes device-mode settings. 
        /// </summary>
        public const int WM_DEVMODECHANGE = (int)WM_Std.WM_DEVMODECHANGE;
        /// <summary>
        /// The WM_ACTIVATEAPP message is sent when a window belonging to a
        /// different application than the active window is about to be
        /// activated. The message is sent to the application whose window is
        /// being activated and to the application whose window is being
        /// deactivated.
        /// </summary>
        public const int WM_ACTIVATEAPP = (int)WM_Std.WM_ACTIVATEAPP;
        /// <summary>
        /// An application sends the WM_FONTCHANGE message to all top-level
        /// windows in the system after changing the pool of font resources. 
        /// </summary>
        public const int WM_FONTCHANGE = (int)WM_Std.WM_FONTCHANGE;
        /// <summary>
        /// A message that is sent whenever there is a change in the system
        /// time.
        /// </summary>
        public const int WM_TIMECHANGE = (int)WM_Std.WM_TIMECHANGE;
        /// <summary>
        /// The WM_CANCELMODE message is sent to cancel certain modes, such
        /// as mouse capture. For example, the system sends this message to
        /// the active window when a dialog box or message box is displayed.
        /// Certain functions also send this message explicitly to the
        /// specified window regardless of whether it is the active window.
        /// For example, the EnableWindow function sends this message when
        /// disabling the specified window.
        /// </summary>
        public const int WM_CANCELMODE = (int)WM_Std.WM_CANCELMODE;
        /// <summary>
        /// The WM_SETCURSOR message is sent to a window if the mouse causes
        /// the cursor to move within a window and mouse input is not
        /// captured. 
        /// </summary>
        public const int WM_SETCURSOR = (int)WM_Std.WM_SETCURSOR;
        /// <summary>
        /// The WM_MOUSEACTIVATE message is sent when the cursor is in an
        /// inactive window and the user presses a mouse button. The parent
        /// window receives this message only if the child window passes it
        /// to the DefWindowProc function.
        /// </summary>
        public const int WM_MOUSEACTIVATE = (int)WM_Std.WM_MOUSEACTIVATE;
        /// <summary>
        /// The WM_CHILDACTIVATE message is sent to a child window when the
        /// user clicks the window's title bar or when the window is
        /// activated, moved, or sized.
        /// </summary>
        public const int WM_CHILDACTIVATE = (int)WM_Std.WM_CHILDACTIVATE;
        /// <summary>
        /// The WM_QUEUESYNC message is sent by a computer-based training
        /// (CBT) application to separate user-input messages from other
        /// messages sent through the WH_JOURNALPLAYBACK Hook procedure. 
        /// </summary>
        public const int WM_QUEUESYNC = (int)WM_Std.WM_QUEUESYNC;
        /// <summary>
        /// The WM_GETMINMAXINFO message is sent to a window when the size
        /// or position of the window is about to change. An application can
        /// use this message to override the window's default maximized size
        /// and position, or its default minimum or maximum tracking size. 
        /// </summary>
        public const int WM_GETMINMAXINFO = (int)WM_Std.WM_GETMINMAXINFO;
        /// <summary>
        /// Windows NT 3.51 and earlier: The WM_PAINTICON message is sent to
        /// a minimized window when the icon is to be painted. This message
        /// is not sent by newer versions of Microsoft Windows, except in
        /// unusual circumstances explained in the Remarks.
        /// </summary>
        public const int WM_PAINTICON = (int)WM_Std.WM_PAINTICON;
        /// <summary>
        /// Windows NT 3.51 and earlier: The WM_ICONERASEBKGND message is
        /// sent to a minimized window when the background of the icon must
        /// be filled before painting the icon. A window receives this
        /// message only if a class icon is defined for the window;
        /// otherwise, WM_ERASEBKGND is sent. This message is not sent by
        /// newer versions of Windows.
        /// </summary>
        public const int WM_ICONERASEBKGND = (int)WM_Std.WM_ICONERASEBKGND;
        /// <summary>
        /// The WM_NEXTDLGCTL message is sent to a dialog box procedure to
        /// set the keyboard focus to a different control in the dialog box. 
        /// </summary>
        public const int WM_NEXTDLGCTL = (int)WM_Std.WM_NEXTDLGCTL;
        /// <summary>
        /// The WM_SPOOLERSTATUS message is sent from Print Manager whenever
        /// a job is added to or removed from the Print Manager queue. 
        /// </summary>
        public const int WM_SPOOLERSTATUS = (int)WM_Std.WM_SPOOLERSTATUS;
        /// <summary>
        /// The WM_DRAWITEM message is sent to the parent window of an owner
        /// -drawn button, combo box, list box, or menu when a visual aspect
        /// of the button, combo box, list box, or menu has changed.
        /// </summary>
        public const int WM_DRAWITEM = (int)WM_Std.WM_DRAWITEM;
        /// <summary>
        /// The WM_MEASUREITEM message is sent to the owner window of a
        /// combo box, list box, list view control, or menu item when the
        /// control or menu is created.
        /// </summary>
        public const int WM_MEASUREITEM = (int)WM_Std.WM_MEASUREITEM;
        /// <summary>
        /// Sent to the owner of a list box or combo box when the list box
        /// or combo box is destroyed or when items are removed by the
        /// LB_DELETESTRING, LB_RESETCONTENT, CB_DELETESTRING, or
        /// CB_RESETCONTENT message. The system sends a WM_DELETEITEM
        /// message for each deleted item. The system sends the
        /// WM_DELETEITEM message for any deleted list box or combo box item
        /// with nonzero item data.
        /// </summary>
        public const int WM_DELETEITEM = (int)WM_Std.WM_DELETEITEM;
        /// <summary>
        /// Sent by a list box with the LBS_WANTKEYBOARDINPUT style to its
        /// owner in response to a WM_KEYDOWN message. 
        /// </summary>
        public const int WM_VKEYTOITEM = (int)WM_Std.WM_VKEYTOITEM;
        /// <summary>
        /// Sent by a list box with the LBS_WANTKEYBOARDINPUT style to its
        /// owner in response to a WM_CHAR message. 
        /// </summary>
        public const int WM_CHARTOITEM = (int)WM_Std.WM_CHARTOITEM;
        /// <summary>
        /// An application sends a WM_SETFONT message to specify the font
        /// that a control is to use when drawing text. 
        /// </summary>
        public const int WM_SETFONT = (int)WM_Std.WM_SETFONT;
        /// <summary>
        /// An application sends a WM_GETFONT message to a control to
        /// retrieve the font with which the control is currently drawing its
        /// text. 
        /// </summary>
        public const int WM_GETFONT = (int)WM_Std.WM_GETFONT;
        /// <summary>
        /// An application sends a WM_SETHOTKEY message to a window to
        /// associate a hot key with the window. When the user presses the
        /// hot key, the system activates the window. 
        /// </summary>
        public const int WM_SETHOTKEY = (int)WM_Std.WM_SETHOTKEY;
        /// <summary>
        /// An application sends a WM_GETHOTKEY message to determine the hot
        /// key associated with a window. 
        /// </summary>
        public const int WM_GETHOTKEY = (int)WM_Std.WM_GETHOTKEY;
        /// <summary>
        /// The WM_QUERYDRAGICON message is sent to a minimized (iconic)
        /// window. The window is about to be dragged by the user but does
        /// not have an icon defined for its class. An application can return
        /// a handle to an icon or cursor. The system displays this cursor or
        /// icon while the user drags the icon.
        /// </summary>
        public const int WM_QUERYDRAGICON = (int)WM_Std.WM_QUERYDRAGICON;
        /// <summary>
        /// The system sends the WM_COMPAREITEM message to determine the
        /// relative position of a new item in the sorted list of an owner
        /// -drawn combo box or list box. Whenever the application adds a new
        /// item, the system sends this message to the owner of a combo box
        /// or list box created with the CBS_SORT or LBS_SORT style. 
        /// </summary>
        public const int WM_COMPAREITEM = (int)WM_Std.WM_COMPAREITEM;
        /// <summary>
        /// Active Accessibility sends the WM_GETOBJECT message to obtain
        /// information about an accessible object contained in a server
        /// application. 
        /// Applications never send this message directly. It is sent only
        /// by Active Accessibility in response to calls to
        /// AccessibleObjectFromPoint, AccessibleObjectFromEvent, or
        /// AccessibleObjectFromWindow. However, server applications handle
        /// this message. 
        /// </summary>
        public const int WM_GETOBJECT = (int)WM_Std.WM_GETOBJECT;
        /// <summary>
        /// The WM_COMPACTING message is sent to all top-level windows when
        /// the system detects more than 12.5 percent of system time over a
        /// 30- to 60-second interval is being spent compacting memory. This
        /// indicates that system memory is low.
        /// </summary>
        public const int WM_COMPACTING = (int)WM_Std.WM_COMPACTING;
        /// <summary>
        /// WM_COMMNOTIFY is Obsolete for Win32-Based Applications
        /// </summary>
        [Obsolete]
        public const int WM_COMMNOTIFY = (int)WM_Std.WM_COMMNOTIFY;
        /// <summary>
        /// The WM_WINDOWPOSCHANGING message is sent to a window whose size,
        /// position, or place in the Z order is about to change as a result
        /// of a call to the SetWindowPos function or another window
        /// -management function.
        /// </summary>
        public const int WM_WINDOWPOSCHANGING = (int)WM_Std.WM_WINDOWPOSCHANGING;
        /// <summary>
        /// The WM_WINDOWPOSCHANGED message is sent to a window whose size,
        /// position, or place in the Z order has changed as a result of a
        /// call to the SetWindowPos function or another window-management
        /// function.
        /// </summary>
        public const int WM_WINDOWPOSCHANGED = (int)WM_Std.WM_WINDOWPOSCHANGED;
        /// <summary>
        /// Notifies applications that the system, typically a battery
        /// -powered personal computer, is about to enter a suspended mode.
        /// Use: POWERBROADCAST
        /// </summary>
        [Obsolete]
        public const int WM_POWER = (int)WM_Std.WM_POWER;
        /// <summary>
        /// An application sends the WM_COPYDATA message to pass data to
        /// another application. 
        /// </summary>
        public const int WM_COPYDATA = (int)WM_Std.WM_COPYDATA;
        /// <summary>
        /// The WM_CANCELJOURNAL message is posted to an application when a
        /// user cancels the application's journaling activities. The message
        /// is posted with a NULL window handle. 
        /// </summary>
        public const int WM_CANCELJOURNAL = (int)WM_Std.WM_CANCELJOURNAL;
        /// <summary>
        /// Sent by a common control to its parent window when an event has
        /// occurred or the control requires some information. 
        /// </summary>
        public const int WM_NOTIFY = (int)WM_Std.WM_NOTIFY;
        /// <summary>
        /// The WM_INPUTLANGCHANGEREQUEST message is posted to the window
        /// with the focus when the user chooses a new input language, either
        /// with the hotkey (specified in the Keyboard control panel 
        /// application) or from the indicator on the system taskbar. An 
        /// application can accept the change by passing the message to the 
        /// DefWindowProc function or reject the change (and prevent it from
        /// taking place) by returning immediately. 
        /// </summary>
        public const int WM_INPUTLANGCHANGEREQUEST = (int)WM_Std.WM_INPUTLANGCHANGEREQUEST;
        /// <summary>
        /// The WM_INPUTLANGCHANGE message is sent to the topmost affected
        /// window after an application's input language has been changed.
        /// You should make any application-specific settings and pass the
        /// message to the DefWindowProc function, which passes the message
        /// to all first-level child windows. These child windows can pass
        /// the message to DefWindowProc to have it pass the message to their
        /// child windows, and so on. 
        /// </summary>
        public const int WM_INPUTLANGCHANGE = (int)WM_Std.WM_INPUTLANGCHANGE;
        /// <summary>
        /// Sent to an application that has initiated a training card with
        /// Microsoft Windows Help. The message informs the application when
        /// the user clicks an authorable button. An application initiates a
        /// training card by specifying the HELP_TCARD command in a call to
        /// the WinHelp function.
        /// </summary>
        public const int WM_TCARD = (int)WM_Std.WM_TCARD;
        /// <summary>
        /// Indicates that the user pressed the F1 key. If a menu is active
        /// when F1 is pressed, WM_HELP is sent to the window associated with
        /// the menu; otherwise, WM_HELP is sent to the window that has the
        /// keyboard focus. If no window has the keyboard focus, WM_HELP is
        /// sent to the currently active window. 
        /// </summary>
        public const int WM_HELP = (int)WM_Std.WM_HELP;
        /// <summary>
        /// The WM_USERCHANGED message is sent to all windows after the user
        /// has logged on or off. When the user logs on or off, the system
        /// updates the user-specific settings. The system sends this message
        /// immediately after updating the settings.
        /// </summary>
        public const int WM_USERCHANGED = (int)WM_Std.WM_USERCHANGED;
        /// <summary>
        /// Determines if a window accepts ANSI or Unicode structures in the
        /// WM_NOTIFY notification message. WM_NOTIFYFORMAT messages are sent
        /// from a common control to its parent window and from the parent
        /// window to the common control.
        /// </summary>
        public const int WM_NOTIFYFORMAT = (int)WM_Std.WM_NOTIFYFORMAT;
        /// <summary>
        /// The WM_CONTEXTMENU message notifies a window that the user
        /// clicked the right mouse button (right-clicked) in the window.
        /// </summary>
        public const int WM_CONTEXTMENU = (int)WM_Std.WM_CONTEXTMENU;
        /// <summary>
        /// The WM_STYLECHANGING message is sent to a window when the
        /// SetWindowLong function is about to change one or more of the
        /// window's styles.
        /// </summary>
        public const int WM_STYLECHANGING = (int)WM_Std.WM_STYLECHANGING;
        /// <summary>
        /// The WM_STYLECHANGED message is sent to a window after the
        /// SetWindowLong function has changed one or more of the window's
        /// styles
        /// </summary>
        public const int WM_STYLECHANGED = (int)WM_Std.WM_STYLECHANGED;
        /// <summary>
        /// The WM_DISPLAYCHANGE message is sent to all windows when the
        /// display resolution has changed.
        /// </summary>
        public const int WM_DISPLAYCHANGE = (int)WM_Std.WM_DISPLAYCHANGE;
        /// <summary>
        /// The WM_GETICON message is sent to a window to retrieve a handle
        /// to the large or small icon associated with a window. The system
        /// displays the large icon in the ALT+TAB dialog, and the small
        /// icon in the window caption. 
        /// </summary>
        public const int WM_GETICON = (int)WM_Std.WM_GETICON;
        /// <summary>
        /// An application sends the WM_SETICON message to associate a new
        /// large or small icon with a window. The system displays the large
        /// icon in the ALT+TAB dialog box, and the small icon in the window
        /// caption. 
        /// </summary>
        public const int WM_SETICON = (int)WM_Std.WM_SETICON;
        /// <summary>
        /// The WM_NCCREATE message is sent prior to the WM_CREATE message
        /// when a window is first created.
        /// </summary>
        public const int WM_NCCREATE = (int)WM_Std.WM_NCCREATE;
        /// <summary>
        /// The WM_NCDESTROY message informs a window that its nonclient area
        /// is being destroyed. The DestroyWindow function sends the
        /// WM_NCDESTROY message to the window following the WM_DESTROY
        /// message. WM_DESTROY is used to free the allocated memory object
        /// associated with the window. 
        /// The WM_NCDESTROY message is sent after the child windows have
        /// been destroyed. In contrast, WM_DESTROY is sent before the child
        /// windows are destroyed.
        /// </summary>
        public const int WM_NCDESTROY = (int)WM_Std.WM_NCDESTROY;
        /// <summary>
        /// The WM_NCCALCSIZE message is sent when the size and position of a
        /// window's client area must be calculated. By processing this
        /// message, an application can control the content of the window's
        /// client area when the size or position of the window changes.
        /// </summary>
        public const int WM_NCCALCSIZE = (int)WM_Std.WM_NCCALCSIZE;
        /// <summary>
        /// The WM_NCHITTEST message is sent to a window when the cursor
        /// moves, or when a mouse button is pressed or released. If the
        /// mouse is not captured, the message is sent to the window beneath
        /// the cursor. Otherwise, the message is sent to the window that has
        /// captured the mouse.
        /// </summary>
        public const int WM_NCHITTEST = (int)WM_Std.WM_NCHITTEST;
        /// <summary>
        /// The WM_NCPAINT message is sent to a window when its frame must be
        /// painted. 
        /// </summary>
        public const int WM_NCPAINT = (int)WM_Std.WM_NCPAINT;
        /// <summary>
        /// The WM_NCACTIVATE message is sent to a window when its nonclient
        /// area needs to be changed to indicate an active or inactive state.
        /// </summary>
        public const int WM_NCACTIVATE = (int)WM_Std.WM_NCACTIVATE;
        /// <summary>
        /// The WM_GETDLGCODE message is sent to the window procedure
        /// associated with a control. By default, the system handles all
        /// keyboard input to the control; the system interprets certain
        /// types of keyboard input as dialog box navigation keys. To
        /// override this default behavior, the control can respond to the
        /// WM_GETDLGCODE message to indicate the types of input it wants to
        /// process itself.
        /// </summary>
        public const int WM_GETDLGCODE = (int)WM_Std.WM_GETDLGCODE;
        /// <summary>
        /// The WM_SYNCPAINT message is used to synchronize painting while
        /// avoiding linking independent GUI threads.
        /// </summary>
        public const int WM_SYNCPAINT = (int)WM_Std.WM_SYNCPAINT;
        /// <summary>
        /// The WM_NCMOUSEMOVE message is posted to a window when the cursor
        /// is moved within the nonclient area of the window. This message is
        /// posted to the window that contains the cursor. If a window has
        /// captured the mouse, this message is not posted.
        /// </summary>
        public const int WM_NCMOUSEMOVE = (int)WM_Std.WM_NCMOUSEMOVE;
        /// <summary>
        /// The WM_NCLBUTTONDOWN message is posted when the user presses the
        /// left mouse button while the cursor is within the nonclient area
        /// of a window. This message is posted to the window that contains
        /// the cursor. If a window has captured the mouse, this message is
        /// not posted.
        /// </summary>
        public const int WM_NCLBUTTONDOWN = (int)WM_Std.WM_NCLBUTTONDOWN;
        /// <summary>
        /// The WM_NCLBUTTONUP message is posted when the user releases the
        /// left mouse button while the cursor is within the nonclient area
        /// of a window. This message is posted to the window that contains
        /// the cursor. If a window has captured the mouse, this message is
        /// not posted.
        /// </summary>
        public const int WM_NCLBUTTONUP = (int)WM_Std.WM_NCLBUTTONUP;
        /// <summary>
        /// The WM_NCLBUTTONDBLCLK message is posted when the user double
        /// -clicks the left mouse button while the cursor is within the
        /// nonclient area of a window. This message is posted to the window
        /// that contains the cursor. If a window has captured the mouse,
        /// this message is not posted.
        /// </summary>
        public const int WM_NCLBUTTONDBLCLK = (int)WM_Std.WM_NCLBUTTONDBLCLK;
        /// <summary>
        /// The WM_NCRBUTTONDOWN message is posted when the user presses the
        /// right mouse button while the cursor is within the nonclient area
        /// of a window. This message is posted to the window that contains
        /// the cursor. If a window has captured the mouse, this message is
        /// not posted.
        /// </summary>
        public const int WM_NCRBUTTONDOWN = (int)WM_Std.WM_NCRBUTTONDOWN;
        /// <summary>
        /// The WM_NCRBUTTONUP message is posted when the user releases the
        /// right mouse button while the cursor is within the nonclient area
        /// of a window. This message is posted to the window that contains
        /// the cursor. If a window has captured the mouse, this message is
        /// not posted.
        /// </summary>
        public const int WM_NCRBUTTONUP = (int)WM_Std.WM_NCRBUTTONUP;
        /// <summary>
        /// The WM_NCRBUTTONDBLCLK message is posted when the user double
        /// -clicks the right mouse button while the cursor is within the
        /// nonclient area of a window. This message is posted to the window
        /// that contains the cursor. If a window has captured the mouse,
        /// this message is not posted.
        /// </summary>
        public const int WM_NCRBUTTONDBLCLK = (int)WM_Std.WM_NCRBUTTONDBLCLK;
        /// <summary>
        /// The WM_NCMBUTTONDOWN message is posted when the user presses
        /// the middle mouse button while the cursor is within the nonclient
        /// area of a window. This message is posted to the window that
        /// contains the cursor. If a window has captured the mouse, this
        /// message is not posted.
        /// </summary>
        public const int WM_NCMBUTTONDOWN = (int)WM_Std.WM_NCMBUTTONDOWN;
        /// <summary>
        /// The WM_NCMBUTTONUP message is posted when the user releases the
        /// middle mouse button while the cursor is within the nonclient
        /// area of a window. This message is posted to the window that
        /// contains the cursor. If a window has captured the mouse, this
        /// message is not posted.
        /// </summary>
        public const int WM_NCMBUTTONUP = (int)WM_Std.WM_NCMBUTTONUP;
        /// <summary>
        /// The WM_NCMBUTTONDBLCLK message is posted when the user double
        /// -clicks the middle mouse button while the cursor is within the
        /// nonclient area of a window. This message is posted to the window
        /// that contains the cursor. If a window has captured the mouse,
        /// this message is not posted.
        /// </summary>
        public const int WM_NCMBUTTONDBLCLK = (int)WM_Std.WM_NCMBUTTONDBLCLK;
        /// <summary>
        /// The WM_NCXBUTTONDOWN message is posted when the user presses the
        /// first or second X button while the cursor is in the nonclient
        /// area of a window. This message is posted to the window that
        /// contains the cursor. If a window has captured the mouse, this
        /// message is not posted.
        /// </summary>
        public const int WM_NCXBUTTONDOWN = (int)WM_Std.WM_NCXBUTTONDOWN;
        /// <summary>
        /// The WM_NCXBUTTONUP message is posted when the user releases the
        /// first or second X button while the cursor is in the nonclient
        /// area of a window. This message is posted to the window that
        /// contains the cursor. If a window has captured the mouse, this
        /// message is not posted.
        /// </summary>
        public const int WM_NCXBUTTONUP = (int)WM_Std.WM_NCXBUTTONUP;
        /// <summary>
        /// The WM_NCXBUTTONDBLCLK message is posted when the user double
        /// -clicks the first or second X button while the cursor is in the
        /// nonclient area of a window. This message is posted to the window
        /// that contains the cursor. If a window has captured the mouse,
        /// this message is not posted.
        /// </summary>
        public const int WM_NCXBUTTONDBLCLK = (int)WM_Std.WM_NCXBUTTONDBLCLK;
        /// <summary>
        /// The WM_INPUT_DEVICE_CHANGE message is sent to the window that
        /// registered to receive raw input. A window receives this message
        /// through its WindowProc function.
        /// </summary>
        public const int WM_INPUT_DEVICE_CHANGE = (int)WM_Std.WM_INPUT_DEVICE_CHANGE;
        /// <summary>
        /// The WM_INPUT message is sent to the window that is getting raw
        /// input. 
        /// </summary>
        public const int WM_INPUT = (int)WM_Std.WM_INPUT;
        /// <summary>
        /// This message filters for keyboard messages.
        /// </summary>
        public const int WM_KEYFIRST = (int)WM_Std.WM_KEYFIRST;
        /// <summary>
        /// The WM_KEYDOWN message is posted to the window with the keyboard
        /// focus when a nonsystem key is pressed. A nonsystem key is a key
        /// that is pressed when the ALT key is not pressed. 
        /// </summary>
        public const int WM_KEYDOWN = (int)WM_Std.WM_KEYDOWN;
        /// <summary>
        /// The WM_KEYUP message is posted to the window with the keyboard
        /// focus when a nonsystem key is released. A nonsystem key is a key
        /// that is pressed when the ALT key is not pressed, or a keyboard
        /// key that is pressed when a window has the keyboard focus. 
        /// </summary>
        public const int WM_KEYUP = (int)WM_Std.WM_KEYUP;
        /// <summary>
        /// The WM_CHAR message is posted to the window with the keyboard
        /// focus when a WM_KEYDOWN message is translated by the TranslateMessage function. The WM_CHAR message contains the character code of the key that was pressed. 
        /// </summary>
        public const int WM_CHAR = (int)WM_Std.WM_CHAR;
        /// <summary>
        /// The WM_DEADCHAR message is posted to the window with the keyboard
        /// focus when a WM_KEYUP message is translated by the
        /// TranslateMessage function. WM_DEADCHAR specifies a character
        /// code generated by a dead key. A dead key is a key that generates
        /// a character, such as the umlaut (double-dot), that is combined
        /// with another character to form a composite character. For
        /// example, the umlaut-O character (Ö) is generated by typing the
        /// dead key for the umlaut character, and then typing the O key. 
        /// </summary>
        public const int WM_DEADCHAR = (int)WM_Std.WM_DEADCHAR;
        /// <summary>
        /// The WM_SYSKEYDOWN message is posted to the window with the
        /// keyboard focus when the user presses the F10 key (which activates
        /// the menu bar) or holds down the ALT key and then presses another
        /// key. It also occurs when no window currently has the keyboard
        /// focus; in this case, the WM_SYSKEYDOWN message is sent to the
        /// active window. The window that receives the message can
        /// distinguish between these two contexts by checking the context
        /// code in the lParam parameter. 
        /// </summary>
        public const int WM_SYSKEYDOWN = (int)WM_Std.WM_SYSKEYDOWN;
        /// <summary>
        /// The WM_SYSKEYUP message is posted to the window with the keyboard
        /// focus when the user releases a key that was pressed while the ALT
        /// key was held down. It also occurs when no window currently has
        /// the keyboard focus; in this case, the WM_SYSKEYUP message is sent
        /// to the active window. The window that receives the message can
        /// distinguish between these two contexts by checking the context
        /// code in the lParam parameter. 
        /// </summary>
        public const int WM_SYSKEYUP = (int)WM_Std.WM_SYSKEYUP;
        /// <summary>
        /// The WM_SYSCHAR message is posted to the window with the keyboard
        /// focus when a WM_SYSKEYDOWN message is translated by the
        /// TranslateMessage function. It specifies the character code of a
        /// system character key — that is, a character key that is pressed
        /// while the ALT key is down. 
        /// </summary>
        public const int WM_SYSCHAR = (int)WM_Std.WM_SYSCHAR;
        /// <summary>
        /// The WM_SYSDEADCHAR message is sent to the window with the
        /// keyboard focus when a WM_SYSKEYDOWN message is translated by the
        /// TranslateMessage function. WM_SYSDEADCHAR specifies the character
        /// code of a system dead key — that is, a dead key that is pressed
        /// while holding down the ALT key. 
        /// </summary>
        public const int WM_SYSDEADCHAR = (int)WM_Std.WM_SYSDEADCHAR;
        /// <summary>
        /// The WM_UNICHAR message is posted to the window with the keyboard
        /// focus when a WM_KEYDOWN message is translated by the
        /// TranslateMessage function. The WM_UNICHAR message contains the
        /// character code of the key that was pressed. 
        /// The WM_UNICHAR message is equivalent to WM_CHAR, but it uses
        /// Unicode Transformation Format (UTF)-32, whereas WM_CHAR uses
        /// UTF-16. It is designed to send or post Unicode characters to
        /// ANSI windows and it can can handle Unicode Supplementary Plane
        /// characters.
        /// </summary>
        public const int WM_UNICHAR = (int)WM_Std.WM_UNICHAR;
        /// <summary>
        /// This message filters for keyboard messages.
        /// </summary>
        public const int WM_KEYLAST = (int)WM_Std.WM_KEYLAST;
        /// <summary>
        /// Sent immediately before the IME generates the composition string
        /// as a result of a keystroke. A window receives this message
        /// through its WindowProc function. 
        /// </summary>
        public const int WM_IME_STARTCOMPOSITION = (int)WM_Std.WM_IME_STARTCOMPOSITION;
        /// <summary>
        /// Sent to an application when the IME ends composition. A window
        /// receives this message through its WindowProc function. 
        /// </summary>
        public const int WM_IME_ENDCOMPOSITION = (int)WM_Std.WM_IME_ENDCOMPOSITION;
        /// <summary>
        /// Sent to an application when the IME changes composition status
        /// as a result of a keystroke. A window receives this message
        /// through its WindowProc function. 
        /// </summary>
        public const int WM_IME_COMPOSITION = (int)WM_Std.WM_IME_COMPOSITION;
        public const int WM_IME_KEYLAST = (int)WM_Std.WM_IME_KEYLAST;
        /// <summary>
        /// The WM_INITDIALOG message is sent to the dialog box procedure
        /// immediately before a dialog box is displayed. Dialog box
        /// procedures typically use this message to initialize controls and
        /// carry out any other initialization tasks that affect the
        /// appearance of the dialog box. 
        /// </summary>
        public const int WM_INITDIALOG = (int)WM_Std.WM_INITDIALOG;
        /// <summary>
        /// The WM_COMMAND message is sent when the user selects a command
        /// item from a menu, when a control sends a notification message to
        /// its parent window, or when an accelerator keystroke is
        /// translated. 
        /// </summary>
        public const int WM_COMMAND = (int)WM_Std.WM_COMMAND;
        /// <summary>
        /// A window receives this message when the user chooses a command
        /// from the Window menu, clicks the maximize button, minimize
        /// button, restore button, close button, or moves the form. You can
        /// stop the form from moving by filtering this out.
        /// </summary>
        public const int WM_SYSCOMMAND = (int)WM_Std.WM_SYSCOMMAND;
        /// <summary>
        /// The WM_TIMER message is posted to the installing thread's message
        /// queue when a timer expires. The message is posted by the
        /// GetMessage or PeekMessage function. 
        /// </summary>
        public const int WM_TIMER = (int)WM_Std.WM_TIMER;
        /// <summary>
        /// The WM_HSCROLL message is sent to a window when a scroll event
        /// occurs in the window's standard horizontal scroll bar. This
        /// message is also sent to the owner of a horizontal scroll bar
        /// control when a scroll event occurs in the control. 
        /// </summary>
        public const int WM_HSCROLL = (int)WM_Std.WM_HSCROLL;
        /// <summary>
        /// The WM_VSCROLL message is sent to a window when a scroll event
        /// occurs in the window's standard vertical scroll bar. This
        /// message is also sent to the owner of a vertical scroll bar
        /// control when a scroll event occurs in the control. 
        /// </summary>
        public const int WM_VSCROLL = (int)WM_Std.WM_VSCROLL;
        /// <summary>
        /// The WM_INITMENU message is sent when a menu is about to become
        /// active. It occurs when the user clicks an item on the menu bar
        /// or presses a menu key. This allows the application to modify the
        /// menu before it is displayed. 
        /// </summary>
        public const int WM_INITMENU = (int)WM_Std.WM_INITMENU;
        /// <summary>
        /// The WM_INITMENUPOPUP message is sent when a drop-down menu or
        /// submenu is about to become active. This allows an application to
        /// modify the menu before it is displayed, without changing the
        /// entire menu. 
        /// </summary>
        public const int WM_INITMENUPOPUP = (int)WM_Std.WM_INITMENUPOPUP;
        /// <summary>
        /// WM_SYSTIMER is a well-known yet still undocumented message.
        /// Windows uses WM_SYSTIMER for internal actions like scrolling.
        /// </summary>
        public const int WM_SYSTIMER = (int)WM_Std.WM_SYSTIMER;
        /// <summary>
        /// The WM_MENUSELECT message is sent to a menu's owner window when
        /// the user selects a menu item. 
        /// </summary>
        public const int WM_MENUSELECT = (int)WM_Std.WM_MENUSELECT;
        /// <summary>
        /// The WM_MENUCHAR message is sent when a menu is active and the
        /// user presses a key that does not correspond to any mnemonic or
        /// accelerator key. This message is sent to the window that owns
        /// the menu. 
        /// </summary>
        public const int WM_MENUCHAR = (int)WM_Std.WM_MENUCHAR;
        /// <summary>
        /// The WM_ENTERIDLE message is sent to the owner window of a modal
        /// dialog box or menu that is entering an idle state. A modal dialog
        /// box or menu enters an idle state when no messages are waiting in
        /// its queue after it has processed one or more previous messages. 
        /// </summary>
        public const int WM_ENTERIDLE = (int)WM_Std.WM_ENTERIDLE;
        /// <summary>
        /// The WM_MENURBUTTONUP message is sent when the user releases the
        /// right mouse button while the cursor is on a menu item. 
        /// </summary>
        public const int WM_MENURBUTTONUP = (int)WM_Std.WM_MENURBUTTONUP;
        /// <summary>
        /// The WM_MENUDRAG message is sent to the owner of a drag-and-drop
        /// menu when the user drags a menu item. 
        /// </summary>
        public const int WM_MENUDRAG = (int)WM_Std.WM_MENUDRAG;
        /// <summary>
        /// The WM_MENUGETOBJECT message is sent to the owner of a drag-and
        /// -drop menu when the mouse cursor enters a menu item or moves
        /// from the center of the item to the top or bottom of the item. 
        /// </summary>
        public const int WM_MENUGETOBJECT = (int)WM_Std.WM_MENUGETOBJECT;
        /// <summary>
        /// The WM_UNINITMENUPOPUP message is sent when a drop-down menu or
        /// submenu has been destroyed. 
        /// </summary>
        public const int WM_UNINITMENUPOPUP = (int)WM_Std.WM_UNINITMENUPOPUP;
        /// <summary>
        /// The WM_MENUCOMMAND message is sent when the user makes a
        /// selection from a menu. 
        /// </summary>
        public const int WM_MENUCOMMAND = (int)WM_Std.WM_MENUCOMMAND;
        /// <summary>
        /// An application sends the WM_CHANGEUISTATE message to indicate
        /// that the user interface (UI) state should be changed.
        /// </summary>
        public const int WM_CHANGEUISTATE = (int)WM_Std.WM_CHANGEUISTATE;
        /// <summary>
        /// An application sends the WM_UPDATEUISTATE message to change the
        /// user interface (UI) state for the specified window and all its
        /// child windows.
        /// </summary>
        public const int WM_UPDATEUISTATE = (int)WM_Std.WM_UPDATEUISTATE;
        /// <summary>
        /// An application sends the WM_QUERYUISTATE message to retrieve the
        /// user interface (UI) state for a window.
        /// </summary>
        public const int WM_QUERYUISTATE = (int)WM_Std.WM_QUERYUISTATE;
        /// <summary>
        /// The WM_CTLCOLORMSGBOX message is sent to the owner window of a
        /// message box before Windows draws the message box. By responding
        /// to this message, the owner window can set the text and background
        /// colors of the message box by using the given display device
        /// context handle. 
        /// </summary>
        public const int WM_CTLCOLORMSGBOX = (int)WM_Std.WM_CTLCOLORMSGBOX;
        /// <summary>
        /// An edit control that is not read-only or disabled sends the
        /// WM_CTLCOLOREDIT message to its parent window when the control is
        /// about to be drawn. By responding to this message, the parent
        /// window can use the specified device context handle to set the
        /// text and background colors of the edit control. 
        /// </summary>
        public const int WM_CTLCOLOREDIT = (int)WM_Std.WM_CTLCOLOREDIT;
        /// <summary>
        /// Sent to the parent window of a list box before the system draws
        /// the list box. By responding to this message, the parent window
        /// can set the text and background colors of the list box by using
        /// the specified display device context handle. 
        /// </summary>
        public const int WM_CTLCOLORLISTBOX = (int)WM_Std.WM_CTLCOLORLISTBOX;
        /// <summary>
        /// The WM_CTLCOLORBTN message is sent to the parent window of a
        /// button before drawing the button. The parent window can change
        /// the button's text and background colors. However, only owner
        /// -drawn buttons respond to the parent window processing this
        /// message. 
        /// </summary>
        public const int WM_CTLCOLORBTN = (int)WM_Std.WM_CTLCOLORBTN;
        /// <summary>
        /// The WM_CTLCOLORDLG message is sent to a dialog box before the
        /// system draws the dialog box. By responding to this message, the
        /// dialog box can set its text and background colors using the
        /// specified display device context handle. 
        /// </summary>
        public const int WM_CTLCOLORDLG = (int)WM_Std.WM_CTLCOLORDLG;
        /// <summary>
        /// The WM_CTLCOLORSCROLLBAR message is sent to the parent window of
        /// a scroll bar control when the control is about to be drawn. By
        /// responding to this message, the parent window can use the display
        /// context handle to set the background color of the scroll bar
        /// control. 
        /// </summary>
        public const int WM_CTLCOLORSCROLLBAR = (int)WM_Std.WM_CTLCOLORSCROLLBAR;
        /// <summary>
        /// A static control, or an edit control that is read-only or
        /// disabled, sends the WM_CTLCOLORSTATIC message to its parent
        /// window when the control is about to be drawn. By responding to
        /// this message, the parent window can use the specified device
        /// context handle to set the text and background colors of the
        /// static control. 
        /// </summary>
        public const int WM_CTLCOLORSTATIC = (int)WM_Std.WM_CTLCOLORSTATIC;
        /// <summary>
        /// Use WM_MOUSEFIRST to specify the first mouse message. Use the
        /// PeekMessage() Function.
        /// </summary>
        public const int WM_MOUSEFIRST = (int)WM_Std.WM_MOUSEFIRST;
        /// <summary>
        /// The WM_MOUSEMOVE message is posted to a window when the cursor
        /// moves. If the mouse is not captured, the message is posted to the
        /// window that contains the cursor. Otherwise, the message is posted
        /// to the window that has captured the mouse.
        /// </summary>
        public const int WM_MOUSEMOVE = (int)WM_Std.WM_MOUSEMOVE;
        /// <summary>
        /// The WM_LBUTTONDOWN message is posted when the user presses the
        /// left mouse button while the cursor is in the client area of a
        /// window. If the mouse is not captured, the message is posted to
        /// the window beneath the cursor. Otherwise, the message is posted
        /// to the window that has captured the mouse.
        /// </summary>
        public const int WM_LBUTTONDOWN = (int)WM_Std.WM_LBUTTONDOWN;
        /// <summary>
        /// The WM_LBUTTONUP message is posted when the user releases the
        /// left mouse button while the cursor is in the client area of a
        /// window. If the mouse is not captured, the message is posted to
        /// the window beneath the cursor. Otherwise, the message is posted
        /// to the window that has captured the mouse.
        /// </summary>
        public const int WM_LBUTTONUP = (int)WM_Std.WM_LBUTTONUP;
        /// <summary>
        /// The WM_LBUTTONDBLCLK message is posted when the user double
        /// -clicks the left mouse button while the cursor is in the client
        /// area of a window. If the mouse is not captured, the message is
        /// posted to the window beneath the cursor. Otherwise, the message
        /// is posted to the window that has captured the mouse.
        /// </summary>
        public const int WM_LBUTTONDBLCLK = (int)WM_Std.WM_LBUTTONDBLCLK;
        /// <summary>
        /// The WM_RBUTTONDOWN message is posted when the user presses the
        /// right mouse button while the cursor is in the client area of a
        /// window. If the mouse is not captured, the message is posted to
        /// the window beneath the cursor. Otherwise, the message is posted
        /// to the window that has captured the mouse.
        /// </summary>
        public const int WM_RBUTTONDOWN = (int)WM_Std.WM_RBUTTONDOWN;
        /// <summary>
        /// The WM_RBUTTONUP message is posted when the user releases the
        /// right mouse button while the cursor is in the client area of a
        /// window. If the mouse is not captured, the message is posted to
        /// the window beneath the cursor. Otherwise, the message is posted
        /// to the window that has captured the mouse.
        /// </summary>
        public const int WM_RBUTTONUP = (int)WM_Std.WM_RBUTTONUP;
        /// <summary>
        /// The WM_RBUTTONDBLCLK message is posted when the user double
        /// -clicks the right mouse button while the cursor is in the client
        /// area of a window. If the mouse is not captured, the message is
        /// posted to the window beneath the cursor. Otherwise, the message
        /// is posted to the window that has captured the mouse.
        /// </summary>
        public const int WM_RBUTTONDBLCLK = (int)WM_Std.WM_RBUTTONDBLCLK;
        /// <summary>
        /// The WM_MBUTTONDOWN message is posted when the user presses the
        /// middle mouse button while the cursor is in the client area of a
        /// window. If the mouse is not captured, the message is posted to
        /// the window beneath the cursor. Otherwise, the message is posted
        /// to the window that has captured the mouse.
        /// </summary>
        public const int WM_MBUTTONDOWN = (int)WM_Std.WM_MBUTTONDOWN;
        /// <summary>
        /// The WM_MBUTTONUP message is posted when the user releases the
        /// middle mouse button while the cursor is in the client area of a
        /// window. If the mouse is not captured, the message is posted to
        /// the window beneath the cursor. Otherwise, the message is posted
        /// to the window that has captured the mouse.
        /// </summary>
        public const int WM_MBUTTONUP = (int)WM_Std.WM_MBUTTONUP;
        /// <summary>
        /// The WM_MBUTTONDBLCLK message is posted when the user double
        /// -clicks the middle mouse button while the cursor is in the client
        /// area of a window. If the mouse is not captured, the message is
        /// posted to the window beneath the cursor. Otherwise, the message
        /// is posted to the window that has captured the mouse.
        /// </summary>
        public const int WM_MBUTTONDBLCLK = (int)WM_Std.WM_MBUTTONDBLCLK;
        /// <summary>
        /// The WM_MOUSEWHEEL message is sent to the focus window when the
        /// mouse wheel is rotated. The DefWindowProc function propagates the
        /// message to the window's parent. There should be no internal
        /// forwarding of the message, since DefWindowProc propagates it up
        /// the parent chain until it finds a window that processes it.
        /// </summary>
        public const int WM_MOUSEWHEEL = (int)WM_Std.WM_MOUSEWHEEL;
        /// <summary>
        /// The WM_XBUTTONDOWN message is posted when the user presses the
        /// first or second X button while the cursor is in the client area
        /// of a window. If the mouse is not captured, the message is posted
        /// to the window beneath the cursor. Otherwise, the message is
        /// posted to the window that has captured the mouse. 
        /// </summary>
        public const int WM_XBUTTONDOWN = (int)WM_Std.WM_XBUTTONDOWN;
        /// <summary>
        /// The WM_XBUTTONUP message is posted when the user releases the
        /// first or second X button while the cursor is in the client area
        /// of a window. If the mouse is not captured, the message is posted
        /// to the window beneath the cursor. Otherwise, the message is
        /// posted to the window that has captured the mouse.
        /// </summary>
        public const int WM_XBUTTONUP = (int)WM_Std.WM_XBUTTONUP;
        /// <summary>
        /// The WM_XBUTTONDBLCLK message is posted when the user double
        /// -clicks the first or second X button while the cursor is in the
        /// client area of a window. If the mouse is not captured, the
        /// message is posted to the window beneath the cursor. Otherwise,
        /// the message is posted to the window that has captured the mouse.
        /// </summary>
        public const int WM_XBUTTONDBLCLK = (int)WM_Std.WM_XBUTTONDBLCLK;
        /// <summary>
        /// The WM_MOUSEHWHEEL message is sent to the focus window when the
        /// mouse's horizontal scroll wheel is tilted or rotated. The
        /// DefWindowProc function propagates the message to the window's
        /// parent. There should be no internal forwarding of the message,
        /// since DefWindowProc propagates it up the parent chain until it
        /// finds a window that processes it.
        /// </summary>
        public const int WM_MOUSEHWHEEL = (int)WM_Std.WM_MOUSEHWHEEL;
        /// <summary>
        /// Use WM_MOUSELAST to specify the last mouse message. Used with
        /// PeekMessage() Function.
        /// </summary>
        public const int WM_MOUSELAST = (int)WM_Std.WM_MOUSELAST;
        /// <summary>
        /// The WM_PARENTNOTIFY message is sent to the parent of a child
        /// window when the child window is created or destroyed, or when
        /// the user clicks a mouse button while the cursor is over the
        /// child window. When the child window is being created, the system
        /// sends WM_PARENTNOTIFY just before the CreateWindow or
        /// CreateWindowEx function that creates the window returns. When
        /// the child window is being destroyed, the system sends the message
        /// before any processing to destroy the window takes place.
        /// </summary>
        public const int WM_PARENTNOTIFY = (int)WM_Std.WM_PARENTNOTIFY;
        /// <summary>
        /// The WM_ENTERMENULOOP message informs an application's main window
        /// procedure that a menu modal loop has been entered. 
        /// </summary>
        public const int WM_ENTERMENULOOP = (int)WM_Std.WM_ENTERMENULOOP;
        /// <summary>
        /// The WM_EXITMENULOOP message informs an application's main window
        /// procedure that a menu modal loop has been exited. 
        /// </summary>
        public const int WM_EXITMENULOOP = (int)WM_Std.WM_EXITMENULOOP;
        /// <summary>
        /// The WM_NEXTMENU message is sent to an application when the right
        /// or left arrow key is used to switch between the menu bar and the
        /// system menu. 
        /// </summary>
        public const int WM_NEXTMENU = (int)WM_Std.WM_NEXTMENU;
        /// <summary>
        /// The WM_SIZING message is sent to a window that the user is
        /// resizing. By processing this message, an application can monitor
        /// the size and position of the drag rectangle and, if needed,
        /// change its size or position. 
        /// </summary>
        public const int WM_SIZING = (int)WM_Std.WM_SIZING;
        /// <summary>
        /// The WM_CAPTURECHANGED message is sent to the window that is
        /// losing the mouse capture.
        /// </summary>
        public const int WM_CAPTURECHANGED = (int)WM_Std.WM_CAPTURECHANGED;
        /// <summary>
        /// The WM_MOVING message is sent to a window that the user is
        /// moving. By processing this message, an application can monitor
        /// the position of the drag rectangle and, if needed, change its
        /// position.
        /// </summary>
        public const int WM_MOVING = (int)WM_Std.WM_MOVING;
        /// <summary>
        /// Notifies applications that a power-management event has occurred.
        /// </summary>
        public const int WM_POWERBROADCAST = (int)WM_Std.WM_POWERBROADCAST;
        /// <summary>
        /// Notifies an application of a change to the hardware configuration
        /// of a device or the computer.
        /// </summary>
        public const int WM_DEVICECHANGE = (int)WM_Std.WM_DEVICECHANGE;
        /// <summary>
        /// An application sends the WM_MDICREATE message to a multiple
        /// -document interface (MDI) client window to create an MDI child
        /// window. 
        /// </summary>
        public const int WM_MDICREATE = (int)WM_Std.WM_MDICREATE;
        /// <summary>
        /// An application sends the WM_MDIDESTROY message to a multiple
        /// -document interface (MDI) client window to close an MDI child
        /// window. 
        /// </summary>
        public const int WM_MDIDESTROY = (int)WM_Std.WM_MDIDESTROY;
        /// <summary>
        /// An application sends the WM_MDIACTIVATE message to a multiple
        /// -document interface (MDI) client window to instruct the client
        /// window to activate a different MDI child window. 
        /// </summary>
        public const int WM_MDIACTIVATE = (int)WM_Std.WM_MDIACTIVATE;
        /// <summary>
        /// An application sends the WM_MDIRESTORE message to a multiple
        /// -document interface (MDI) client window to restore an MDI
        /// child window from maximized or minimized size. 
        /// </summary>
        public const int WM_MDIRESTORE = (int)WM_Std.WM_MDIRESTORE;
        /// <summary>
        /// An application sends the WM_MDINEXT message to a multiple
        /// -document interface (MDI) client window to activate the next
        /// or previous child window. 
        /// </summary>
        public const int WM_MDINEXT = (int)WM_Std.WM_MDINEXT;
        /// <summary>
        /// An application sends the WM_MDIMAXIMIZE message to a multiple
        /// -document interface (MDI) client window to maximize an MDI child
        /// window. The system resizes the child window to make its client
        /// area fill the client window. The system places the child window's
        /// window menu icon in the rightmost position of the frame window's
        /// menu bar, and places the child window's restore icon in the
        /// leftmost position. The system also appends the title bar text of
        /// the child window to that of the frame window. 
        /// </summary>
        public const int WM_MDIMAXIMIZE = (int)WM_Std.WM_MDIMAXIMIZE;
        /// <summary>
        /// An application sends the WM_MDITILE message to a multiple
        /// -document interface (MDI) client window to arrange all of its
        /// MDI child windows in a tile format. 
        /// </summary>
        public const int WM_MDITILE = (int)WM_Std.WM_MDITILE;
        /// <summary>
        /// An application sends the WM_MDICASCADE message to a multiple
        /// -document interface (MDI) client window to arrange all its child
        /// windows in a cascade format. 
        /// </summary>
        public const int WM_MDICASCADE = (int)WM_Std.WM_MDICASCADE;
        /// <summary>
        /// An application sends the WM_MDIICONARRANGE message to a multiple
        /// -document interface (MDI) client window to arrange all minimized
        /// MDI child windows. It does not affect child windows that are not
        /// minimized. 
        /// </summary>
        public const int WM_MDIICONARRANGE = (int)WM_Std.WM_MDIICONARRANGE;
        /// <summary>
        /// An application sends the WM_MDIGETACTIVE message to a multiple
        /// -document interface (MDI) client window to retrieve the handle
        /// to the active MDI child window. 
        /// </summary>
        public const int WM_MDIGETACTIVE = (int)WM_Std.WM_MDIGETACTIVE;
        /// <summary>
        /// An application sends the WM_MDISETMENU message to a multiple
        /// -document interface (MDI) client window to replace the entire
        /// menu of an MDI frame window, to replace the window menu of the
        /// frame window, or both. 
        /// </summary>
        public const int WM_MDISETMENU = (int)WM_Std.WM_MDISETMENU;
        /// <summary>
        /// The WM_ENTERSIZEMOVE message is sent one time to a window after
        /// it enters the moving or sizing modal loop. The window enters
        /// the moving or sizing modal loop when the user clicks the window's
        /// title bar or sizing border, or when the window passes the
        /// WM_SYSCOMMAND message to the DefWindowProc function and the
        /// wParam parameter of the message specifies the SC_MOVE or SC_SIZE
        /// value. The operation is complete when DefWindowProc returns. 
        /// The system sends the WM_ENTERSIZEMOVE message regardless of
        /// whether the dragging of full windows is enabled.
        /// </summary>
        public const int WM_ENTERSIZEMOVE = (int)WM_Std.WM_ENTERSIZEMOVE;
        /// <summary>
        /// The WM_EXITSIZEMOVE message is sent one time to a window, after
        /// it has exited the moving or sizing modal loop. The window enters
        /// the moving or sizing modal loop when the user clicks the window's
        /// title bar or sizing border, or when the window passes the
        /// WM_SYSCOMMAND message to the DefWindowProc function and the
        /// wParam parameter of the message specifies the SC_MOVE or SC_SIZE
        /// value. The operation is complete when DefWindowProc returns. 
        /// </summary>
        public const int WM_EXITSIZEMOVE = (int)WM_Std.WM_EXITSIZEMOVE;
        /// <summary>
        /// Sent when the user drops a file on the window of an application
        /// that has registered itself as a recipient of dropped files.
        /// </summary>
        public const int WM_DROPFILES = (int)WM_Std.WM_DROPFILES;
        /// <summary>
        /// An application sends the WM_MDIREFRESHMENU message to a multiple
        /// -document interface (MDI) client window to refresh the window
        /// menu of the MDI frame window. 
        /// </summary>
        public const int WM_MDIREFRESHMENU = (int)WM_Std.WM_MDIREFRESHMENU;
        /// <summary>
        /// Sent to an application when a window is activated. A window
        /// receives this message through its WindowProc function. 
        /// </summary>
        public const int WM_IME_SETCONTEXT = (int)WM_Std.WM_IME_SETCONTEXT;
        /// <summary>
        /// Sent to an application to notify it of changes to the IME window.
        /// A window receives this message through its WindowProc function. 
        /// </summary>
        public const int WM_IME_NOTIFY = (int)WM_Std.WM_IME_NOTIFY;
        /// <summary>
        /// Sent by an application to direct the IME window to carry out the
        /// requested command. The application uses this message to control
        /// the IME window that it has created. To send this message, the
        /// application calls the SendMessage function with the following
        /// parameters.
        /// </summary>
        public const int WM_IME_CONTROL = (int)WM_Std.WM_IME_CONTROL;
        /// <summary>
        /// Sent to an application when the IME window finds no space to
        /// extend the area for the composition window. A window receives
        /// this message through its WindowProc function. 
        /// </summary>
        public const int WM_IME_COMPOSITIONFULL = (int)WM_Std.WM_IME_COMPOSITIONFULL;
        /// <summary>
        /// Sent to an application when the operating system is about to
        /// change the current IME. A window receives this message through
        /// its WindowProc function. 
        /// </summary>
        public const int WM_IME_SELECT = (int)WM_Std.WM_IME_SELECT;
        /// <summary>
        /// Sent to an application when the IME gets a character of the
        /// conversion result. A window receives this message through its
        /// WindowProc function. 
        /// </summary>
        public const int WM_IME_CHAR = (int)WM_Std.WM_IME_CHAR;
        /// <summary>
        /// Sent to an application to provide commands and request
        /// information. A window receives this message through its
        /// WindowProc function. 
        /// </summary>
        public const int WM_IME_REQUEST = (int)WM_Std.WM_IME_REQUEST;
        /// <summary>
        /// Sent to an application by the IME to notify the application of a
        /// key press and to keep message order. A window receives this
        /// message through its WindowProc function. 
        /// </summary>
        public const int WM_IME_KEYDOWN = (int)WM_Std.WM_IME_KEYDOWN;
        /// <summary>
        /// Sent to an application by the IME to notify the application of a
        /// key release and to keep message order. A window receives this
        /// message through its WindowProc function. 
        /// </summary>
        public const int WM_IME_KEYUP = (int)WM_Std.WM_IME_KEYUP;
        /// <summary>
        /// The WM_MOUSEHOVER message is posted to a window when the cursor
        /// hovers over the client area of the window for the period of time
        /// specified in a prior call to TrackMouseEvent.
        /// </summary>
        public const int WM_MOUSEHOVER = (int)WM_Std.WM_MOUSEHOVER;
        /// <summary>
        /// The WM_MOUSELEAVE message is posted to a window when the cursor
        /// leaves the client area of the window specified in a prior call to
        /// TrackMouseEvent.
        /// </summary>
        public const int WM_MOUSELEAVE = (int)WM_Std.WM_MOUSELEAVE;
        /// <summary>
        /// The WM_NCMOUSEHOVER message is posted to a window when the cursor
        /// hovers over the nonclient area of the window for the period of
        /// time specified in a prior call to TrackMouseEvent.
        /// </summary>
        public const int WM_NCMOUSEHOVER = (int)WM_Std.WM_NCMOUSEHOVER;
        /// <summary>
        /// The WM_NCMOUSELEAVE message is posted to a window when the cursor
        /// leaves the nonclient area of the window specified in a prior call
        /// to TrackMouseEvent.
        /// </summary>
        public const int WM_NCMOUSELEAVE = (int)WM_Std.WM_NCMOUSELEAVE;
        /// <summary>
        /// The WM_WTSSESSION_CHANGE message notifies applications of changes
        /// in session state.
        /// </summary>
        public const int WM_WTSSESSION_CHANGE = (int)WM_Std.WM_WTSSESSION_CHANGE;
        public const int WM_TABLET_FIRST = (int)WM_Std.WM_TABLET_FIRST;
        public const int WM_TABLET_LAST = (int)WM_Std.WM_TABLET_LAST;
        /// <summary>
        /// An application sends a WM_CUT message to an edit control or combo
        /// box to delete (cut) the current selection, if any, in the edit
        /// control and copy the deleted text to the clipboard in CF_TEXT
        /// format. 
        /// </summary>
        public const int WM_CUT = (int)WM_Std.WM_CUT;
        /// <summary>
        /// An application sends the WM_COPY message to an edit control or
        /// combo box to copy the current selection to the clipboard in
        /// CF_TEXT format. 
        /// </summary>
        public const int WM_COPY = (int)WM_Std.WM_COPY;
        /// <summary>
        /// An application sends a WM_PASTE message to an edit control or
        /// combo box to copy the current content of the clipboard to the
        /// edit control at the current caret position. Data is inserted
        /// only if the clipboard contains data in CF_TEXT format. 
        /// </summary>
        public const int WM_PASTE = (int)WM_Std.WM_PASTE;
        /// <summary>
        /// An application sends a WM_CLEAR message to an edit control or
        /// combo box to delete (clear) the current selection, if any, from
        /// the edit control. 
        /// </summary>
        public const int WM_CLEAR = (int)WM_Std.WM_CLEAR;
        /// <summary>
        /// An application sends a WM_UNDO message to an edit control to
        /// undo the last operation. When this message is sent to an edit
        /// control, the previously deleted text is restored or the
        /// previously added text is deleted.
        /// </summary>
        public const int WM_UNDO = (int)WM_Std.WM_UNDO;
        /// <summary>
        /// The WM_RENDERFORMAT message is sent to the clipboard owner if it
        /// has delayed rendering a specific clipboard format and if an
        /// application has requested data in that format. The clipboard
        /// owner must render data in the specified format and place it on
        /// the clipboard by calling the SetClipboardData function. 
        /// </summary>
        public const int WM_RENDERFORMAT = (int)WM_Std.WM_RENDERFORMAT;
        /// <summary>
        /// The WM_RENDERALLFORMATS message is sent to the clipboard owner
        /// before it is destroyed, if the clipboard owner has delayed
        /// rendering one or more clipboard formats. For the content of the
        /// clipboard to remain available to other applications, the
        /// clipboard owner must render data in all the formats it is capable
        /// of generating, and place the data on the clipboard by calling
        /// the SetClipboardData function. 
        /// </summary>
        public const int WM_RENDERALLFORMATS = (int)WM_Std.WM_RENDERALLFORMATS;
        /// <summary>
        /// The WM_DESTROYCLIPBOARD message is sent to the clipboard owner
        /// when a call to the EmptyClipboard function empties the clipboard. 
        /// </summary>
        public const int WM_DESTROYCLIPBOARD = (int)WM_Std.WM_DESTROYCLIPBOARD;
        /// <summary>
        /// The WM_DRAWCLIPBOARD message is sent to the first window in the
        /// clipboard viewer chain when the content of the clipboard changes.
        /// This enables a clipboard viewer window to display the new content
        /// of the clipboard. 
        /// </summary>
        public const int WM_DRAWCLIPBOARD = (int)WM_Std.WM_DRAWCLIPBOARD;
        /// <summary>
        /// The WM_PAINTCLIPBOARD message is sent to the clipboard owner by
        /// a clipboard viewer window when the clipboard contains data in
        /// the CF_OWNERDISPLAY format and the clipboard viewer's client
        /// area needs repainting. 
        /// </summary>
        public const int WM_PAINTCLIPBOARD = (int)WM_Std.WM_PAINTCLIPBOARD;
        /// <summary>
        /// The WM_VSCROLLCLIPBOARD message is sent to the clipboard owner
        /// by a clipboard viewer window when the clipboard contains data in
        /// the CF_OWNERDISPLAY format and an event occurs in the clipboard
        /// viewer's vertical scroll bar. The owner should scroll the
        /// clipboard image and update the scroll bar values. 
        /// </summary>
        public const int WM_VSCROLLCLIPBOARD = (int)WM_Std.WM_VSCROLLCLIPBOARD;
        /// <summary>
        /// The WM_SIZECLIPBOARD message is sent to the clipboard owner by a
        /// clipboard viewer window when the clipboard contains data in the
        /// CF_OWNERDISPLAY format and the clipboard viewer's client area has
        /// changed size. 
        /// </summary>
        public const int WM_SIZECLIPBOARD = (int)WM_Std.WM_SIZECLIPBOARD;
        /// <summary>
        /// The WM_ASKCBFORMATNAME message is sent to the clipboard owner by
        /// a clipboard viewer window to request the name of a CF_OWNERDISPLAY
        /// clipboard format.
        /// </summary>
        public const int WM_ASKCBFORMATNAME = (int)WM_Std.WM_ASKCBFORMATNAME;
        /// <summary>
        /// The WM_CHANGECBCHAIN message is sent to the first window in the
        /// clipboard viewer chain when a window is being removed from the
        /// chain. 
        /// </summary>
        public const int WM_CHANGECBCHAIN = (int)WM_Std.WM_CHANGECBCHAIN;
        /// <summary>
        /// The WM_HSCROLLCLIPBOARD message is sent to the clipboard owner by
        /// a clipboard viewer window. This occurs when the clipboard contains
        /// data in the CF_OWNERDISPLAY format and an event occurs in the
        /// clipboard viewer's horizontal scroll bar. The owner should scroll
        /// the clipboard image and update the scroll bar values. 
        /// </summary>
        public const int WM_HSCROLLCLIPBOARD = (int)WM_Std.WM_HSCROLLCLIPBOARD;
        /// <summary>
        /// This message informs a window that it is about to receive the
        /// keyboard focus, giving the window the opportunity to realize its
        /// logical palette when it receives the focus. 
        /// </summary>
        public const int WM_QUERYNEWPALETTE = (int)WM_Std.WM_QUERYNEWPALETTE;
        /// <summary>
        /// The WM_PALETTEISCHANGING message informs applications that an
        /// application is going to realize its logical palette. 
        /// </summary>
        public const int WM_PALETTEISCHANGING = (int)WM_Std.WM_PALETTEISCHANGING;
        /// <summary>
        /// This message is sent by the OS to all top-level and overlapped
        /// windows after the window with the keyboard focus realizes its
        /// logical palette. 
        /// This message enables windows that do not have the keyboard focus
        /// to realize their logical palettes and update their client areas.
        /// </summary>
        public const int WM_PALETTECHANGED = (int)WM_Std.WM_PALETTECHANGED;
        /// <summary>
        /// The WM_HOTKEY message is posted when the user presses a hot key
        /// registered by the RegisterHotKey function. The message is placed
        /// at the top of the message queue associated with the thread that
        /// registered the hot key. 
        /// </summary>
        public const int WM_HOTKEY = (int)WM_Std.WM_HOTKEY;
        /// <summary>
        /// The WM_PRINT message is sent to a window to request that it draw
        /// itself in the specified device context, most commonly in a printer
        /// device context.
        /// </summary>
        public const int WM_PRINT = (int)WM_Std.WM_PRINT;
        /// <summary>
        /// The WM_PRINTCLIENT message is sent to a window to request that it
        /// draw its client area in the specified device context, most
        /// commonly in a printer device context.
        /// </summary>
        public const int WM_PRINTCLIENT = (int)WM_Std.WM_PRINTCLIENT;
        /// <summary>
        /// The WM_APPCOMMAND message notifies a window that the user
        /// generated an application command event, for example, by clicking
        /// an application command button using the mouse or typing an
        /// application command key on the keyboard.
        /// </summary>
        public const int WM_APPCOMMAND = (int)WM_Std.WM_APPCOMMAND;
        /// <summary>
        /// The WM_THEMECHANGED message is broadcast to every window following
        /// a theme change event. Examples of theme change events are the
        /// activation of a theme, the deactivation of a theme, or a
        /// transition from one theme to another.
        /// </summary>
        public const int WM_THEMECHANGED = (int)WM_Std.WM_THEMECHANGED;
        /// <summary>
        /// Sent when the contents of the clipboard have changed.
        /// </summary>
        public const int WM_CLIPBOARDUPDATE = (int)WM_Std.WM_CLIPBOARDUPDATE;
        /// <summary>
        /// The system will send a window the WM_DWMCOMPOSITIONCHANGED
        /// message to indicate that the availability of desktop composition
        /// has changed.
        /// </summary>
        public const int WM_DWMCOMPOSITIONCHANGED = (int)WM_Std.WM_DWMCOMPOSITIONCHANGED;
        /// <summary>
        /// WM_DWMNCRENDERINGCHANGED is called when the non-client area
        /// rendering status of a window has changed. Only windows that have
        /// set the flag DWM_BLURBEHIND.fTransitionOnMaximized to true will
        /// get this message. 
        /// </summary>
        public const int WM_DWMNCRENDERINGCHANGED = (int)WM_Std.WM_DWMNCRENDERINGCHANGED;
        /// <summary>
        /// Sent to all top-level windows when the colorization color has
        /// changed. 
        /// </summary>
        public const int WM_DWMCOLORIZATIONCOLORCHANGED = (int)WM_Std.WM_DWMCOLORIZATIONCOLORCHANGED;
        /// <summary>
        /// WM_DWMWINDOWMAXIMIZEDCHANGE will let you know when a DWM composed
        /// window is maximized. You also have to register for this message as
        /// well. You'd have other windowd go opaque when this message is
        /// sent.
        /// </summary>
        public const int WM_DWMWINDOWMAXIMIZEDCHANGE = (int)WM_Std.WM_DWMWINDOWMAXIMIZEDCHANGE;
        /// <summary>
        /// Sent to request extended title bar information. A window receives
        /// this message through its WindowProc function.
        /// </summary>
        public const int WM_GETTITLEBARINFOEX = (int)WM_Std.WM_GETTITLEBARINFOEX;
        public const int WM_HANDHELDFIRST = (int)WM_Std.WM_HANDHELDFIRST;
        public const int WM_HANDHELDLAST = (int)WM_Std.WM_HANDHELDLAST;
        public const int WM_AFXFIRST = (int)WM_Std.WM_AFXFIRST;
        public const int WM_AFXLAST = (int)WM_Std.WM_AFXLAST;
        public const int WM_PENWINFIRST = (int)WM_Std.WM_PENWINFIRST;
        public const int WM_PENWINLAST = (int)WM_Std.WM_PENWINLAST;
        /// <summary>
        /// The WM_APP constant is used by applications to help define
        /// private messages, usually of the form WM_APP+X, where X is an
        /// integer value. 
        /// </summary>
        public const int WM_APP = (int)WM_Std.WM_APP;
        /// <summary>
        /// The WM_USER constant is used by applications to help define
        /// private messages for use by private window classes, usually of
        /// the form WM_USER+X, where X is an integer value. 
        /// </summary>
        public const int WM_USER = (int)WM_Std.WM_USER;
        /// <summary>
        /// The WM_REFLECT constant is used in combination with another
        /// message to send messages to the control before it is sent to its
        /// parent
        /// </summary>
        public const int WM_REFLECT = (int)WM_Std.WM_REFLECT;

        /// <summary>
        /// An application sends the WM_CPL_LAUNCH message to Windows Control
        /// Panel to request that a Control Panel application be started. 
        /// </summary>
        public const int CPL_LAUNCH = (int)WM_Std.CPL_LAUNCH;
        /// <summary>
        /// The WM_CPL_LAUNCHED message is sent when a Control Panel
        /// application, started by the WM_CPL_LAUNCH message, has closed.
        /// The WM_CPL_LAUNCHED message is sent to the window identified by
        /// the wParam parameter of the WM_CPL_LAUNCH message that started
        /// the application. 
        /// </summary>
        public const int CPL_LAUNCHED = (int)WM_Std.CPL_LAUNCHED;
        #endregion
    }
}
