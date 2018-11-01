using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace IkorinLib.Wpf
{
    public static class WindowHelper
    {
        /// <summary>
        /// ウィンドウの位置を設定します。 
        /// ※SourceInitializedイベントから呼び出してください
        /// </summary>
        /// <param name="window">対象のウィンドウ</param>
        /// <param name="placement">ウィンドウの位置</param>
        public static void SetWindowPlace(Window window, WINDOWPLACEMENT placement)
        {
            var hwnd = new WindowInteropHelper(window).Handle;
            WindowPlace.SetWindowPlacement(hwnd, ref placement);
        }

        /// <summary>
        /// ウィンドウの位置を取得します。
        /// ※Closingイベントから呼び出してください
        /// </summary>
        /// <param name="window">対象のウィンドウ</param>
        /// <returns>ウィンドウの位置</returns>
        public static WINDOWPLACEMENT GetWindowPlace(Window window)
        {
            var hwnd = new WindowInteropHelper(window).Handle;
            WINDOWPLACEMENT place;
            WindowPlace.GetWindowPlacement(hwnd, out place);
            return place;
        }
    }
}
