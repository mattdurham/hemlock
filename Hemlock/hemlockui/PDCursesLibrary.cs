using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace hemlockui
{
    public class PDCursesLibrary
    {
        public const Int32 ERR = -1;

        #region Default Colors
        public const Int32 COLOR_BLACK = 0;
        public const Int32 COLOR_RED = 1;
        public const Int32 COLOR_GREEN = 2;
        public const Int32 COLOR_YELLOW = 3;
        public const Int32 COLOR_BLUE = 4;
        public const Int32 COLOR_MAGENTA = 5;
        public const Int32 COLOR_CYAN = 6;
        public const Int32 COLOR_WHITE = 7;
        #endregion

        #region Attributes
        public const Int32 A_NORMAL = 0;
        public const Int32 A_BOLD = 0x10000000;
        public const Int32 A_UNDERLINE = 0x00100000;
        public const Int32 A_BLINK = 0x00400000;
        #endregion

        /// <summary>
        /// This sleeps for x milliseconds
        /// </summary>
        /// <param name="milliseconds"></param>
        /// <returns>ERR if something bad occurs</returns>
        [DllImport("pdcurses.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 napms(Int32 milliseconds);

        [DllImport("pdcurses.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 move(Int32 x, Int32 y);

        [DllImport("pdcurses.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 endwin();

        [DllImport("pdcurses.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 erase();


        [DllImport("pdcurses.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 mvaddstr(Int32 y, Int32 x, string text);

        [DllImport("pdcurses.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 attrset(Int32 attrs);

        [DllImport("pdcurses.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 start_color();


        [DllImport("pdcurses.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 attron(Int32 attribute);

        [DllImport("pdcurses.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 attroff(Int32 attribute);
      

        [DllImport("pdcurses.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool has_colors();

        [DllImport("pdcurses.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr initscr();

        [DllImport("pdcurses.dll", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 printw(string format, __arglist);

        [DllImport("pdcurses.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void refresh();

        [DllImport("pdcurses.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 wgetch(IntPtr window);

        [DllImport("pdcurses.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 nodelay(IntPtr window, bool bf);

        [DllImport("pdcurses.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 noecho();

        [DllImport("pdcurses.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 nonl();

        [DllImport("pdcurses.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 init_pair(short pair, Int32 foreground, Int32 background);


        [DllImport("kernel32.dll")]
        internal static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        internal static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        public static int LINES
        {
            get
            {
                var lines = Marshal.ReadIntPtr(GetProcAddress(GetModuleHandle("pdcurses.dll"), "LINES"));
                return (int)lines;
            }
        }

        public static int COLUMNS
        {
            get
            {
                var columns = Marshal.ReadIntPtr(GetProcAddress(GetModuleHandle("pdcurses.dll"), "COLS"));
                return (int)columns;
            }
        }

      
    }
}
