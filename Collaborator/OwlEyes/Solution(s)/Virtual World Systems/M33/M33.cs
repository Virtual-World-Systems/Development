using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace M33
{
    public class M33<T> where T : new()
    {
        public M33() { }

        T @object = defObj;
        static T defObj = new T();

        T[] border = null;
        void _verifyBorder() { if (border == null) border = Enumerable.Repeat<T>(defObj, 8).ToArray(); }

        int XYtoIX(int x, int y) { int i = 3 * y + x; if (i == 4) return -1; if (i < 4) return i; return i - 1; }
        (int, int) IXtoXY(int i) { if (i == -1) return (1, 1); if (i >= 4) i++; return (i % 3, i / 3); }

        public T this[int x, int y]
        {
            get
            {
                if ((x == 1) && (y == 1)) return @object;
                if (border == null) return new T();
                return border[XYtoIX(x, y)];
            }
            set
            {
                T val = value;
                if (defObj.Equals(val)) val = defObj;
                T old = defObj;
                int i = XYtoIX(x, y);
                if (i == -1)
                {
                    old = @object;
                    if (old.Equals(val)) return;
                    //if (TEST == 6)
                    //{
                    //    TEST = TEST * 2;
                    //    TEST = TEST / 2;
                    //}
                    //_changing(x, y, old, val);
                    @object = val;
                    _changed(x, y, old, val);
                    return;
                }
                //if (TEST == 6)
                //{
                //    TEST = TEST * 2;
                //    TEST = TEST / 2;
                //}
                if (border != null) old = border[i];
                if (old.Equals(val)) return;
                if (!_changing(x, y, old, val)) return;
                _verifyBorder(); border[i] = val;
                _changed(x, y, old, val);
            }
        }
        bool _changing(int x, int y, T old, T @new)
        {
            Debug.WriteLine($"M33: changing [{x},{y}] from {{{old}}} to {{{@new}}}");
            return true;
        }
        void _changed(int x, int y, T old, T @new)
        {
            if (defObj.Equals(@new) && ((x != 1) || (y != 1)))
            {
                bool clear = true;
				//if (TEST == 9)
				//{
				//	TEST = TEST * 2;
				//	TEST = TEST / 2;
				//}
				foreach (T o in border) if (!defObj.Equals(o)) { clear = false; break; }
                if (clear)
                {
                    border = null;
                    Debug.WriteLine("M33: cleared border");
                }
            }
        }
        string _toString(T o) { if (defObj.Equals(o)) return ""; return "" + o; }

        public override string ToString()
        {
            string[] ss = new string[9];
            for (int i = 0; i < 4; i++) ss[i] = ((border == null) ? "" : _toString(border[i]));
            ss[4] = _toString(@object);
            for (int i = 4; i < 8; i++) ss[i + 1] = ((border == null) ? "" : _toString(border[i]));
			int lm = 0; for (int i = 0; i < 9; i++) lm = Math.Max(lm, ss[i].Length);
			for (int i = 0; i < 9; i++) ss[i] = ss[i].PadLeft(lm, ' ');
			StringBuilder sb = new StringBuilder();
            for (int y = 0; y < 3; y++)
            {
                sb.Append("\r\n");
                for (int x = 0; x < 3; x++) sb.Append(" {").Append(ss[y * 3 + x]).Append("}");
            }
            return sb.ToString();
        }

        static internal int TEST;
    }

    public static class Program
    { 
        public static void Main()
        {
            M33<int>.TEST = 1; M33<int> M = new M33<int>();
            Debug.WriteLine("T1: " + M.ToString());
			M33<int>.TEST = 2; M[1, 1] = 12; Debug.WriteLine("T2: " + M.ToString());
			M33<int>.TEST = 3; M[0, 1] = 1;  Debug.WriteLine("T3: " + M.ToString());
			M33<int>.TEST = 4; M[1, 1] = 13; Debug.WriteLine("T4: " + M.ToString());
			M33<int>.TEST = 5; M[2, 2] = 22; Debug.WriteLine("T5: " + M.ToString());
			M33<int>.TEST = 6; M[2, 2] = 22; Debug.WriteLine("T6: " + M.ToString());
			M33<int>.TEST = 7; M[2, 2] = 27; Debug.WriteLine("T7: " + M.ToString());
			M33<int>.TEST = 8; M[2, 2] = 0;  Debug.WriteLine("T8: " + M.ToString());
			M33<int>.TEST = 9; M[0, 1] = 0;  Debug.WriteLine("T9: " + M.ToString());
		}
	}
}
