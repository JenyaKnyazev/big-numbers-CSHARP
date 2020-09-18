using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigNumbers
{
    class BigInteger
    {
        private List<char> list = new List<char>();

        public BigInteger(string str) {
            foreach (char i in str)
                list.Add((char)(i - 48));
            delete_zero();
        }
        public BigInteger() {
            
        }
        public void initialize(string str)
        {
            list.Clear();
            foreach (char i in str)
                list.Add((char)(i - 48));
            delete_zero();
        }
        public override string ToString() {
            string str="";
            delete_zero();
            foreach (char i in list)
                str += (char)(i + 48);
            return str;
        }
        private void delete_zero() {
            while (list.Count() > 1 && list[0] == (char)('0' - 48))
                    list.RemoveAt(0);
        }
        private void refresh() {
            int n = 0;
            for (int i = list.Count() - 1; i >= 0; i--){
                list[i] += (char)n;
                n = list[i] / 10;
                list[i] = (char)(list[i] % 10);
            }
            if (n>0)
                list.Insert(0, (char)n);
        }
        private void copy(BigInteger a, BigInteger b) {
            a.list.Clear();
            foreach (char i in b.list)
                a.list.Add(i);
        }
        public BigInteger plus(BigInteger a,BigInteger b) {
            BigInteger res = new BigInteger();
            copy(res, a);
            while (res.list.Count() < b.list.Count())
                res.list.Insert(0, (char)0);
            for (int i = res.list.Count() - 1, r = b.list.Count() - 1; i >= 0 && r >= 0; i--, r--)
                res.list[i] += b.list[r];
            res.refresh();
            return res;
        }
        private void refresh2(){
            for(int i=0;i<list.Count()-1;i++){
                list[i]--;
                list[i + 1] += (char)10;
            }
            refresh();
            delete_zero();
        }
        private BigInteger minus_part1(BigInteger a, BigInteger b) { 
            BigInteger res=new BigInteger();
            copy(res,a);
            for (int i =res.list.Count()- 1, r = b.list.Count() - 1; i >= 0 && r >= 0;r--,i-- )
                res.list[i]-=b.list[r];
            res.refresh2();
            return res;
        }
        private int compare(BigInteger a, BigInteger b) {
            if (a.list.Count() > b.list.Count())
                return 1;
            if (a.list.Count() < b.list.Count())
                return -1;
            for (int i = 0; i < a.list.Count; i++){
                if (a.list[i] > b.list[i])
                    return 1;
                if (a.list[i] < b.list[i])
                    return -1;
            }
                return 0;
        }
        public BigInteger minus(BigInteger a, BigInteger b) {
            BigInteger res = new BigInteger();
            BigInteger temp = new BigInteger();
            bool is_negative = false;
            if (compare(a, b) == 1)
            {
                copy(res, a);
                copy(temp, b);
            }
            else if (compare(a, b) == -1)
            {
                is_negative = true;
                copy(res, b);
                copy(temp, a);
            }
            else {
                return new BigInteger("0");
            }
            res=minus_part1(res, temp);
            if (is_negative)
                res.list.Insert(0,(char)("-"[0]-48));
            return res;
        }
        public BigInteger multiply(BigInteger a, BigInteger b) {
            BigInteger res = new BigInteger();
            for (int i = 0; i < a.list.Count(); i++)
                res.list.Add((char)('0' - 48));
            for (int i = 0; i < b.list.Count(); i++)
                res.list.Add((char)('0' - 48));
            for (int r = b.list.Count() - 1; r >= 0; r--) { 
                int k=res.list.Count()-1-(b.list.Count()-1-r);
                for (int i = a.list.Count() - 1; i >= 0; i--, k--)
                    res.list[k] += (char)(a.list[i] * b.list[r]);
                res.refresh();
            }
            res.delete_zero();
            return res;
        }
        public BigInteger division(BigInteger a, BigInteger b) {
            BigInteger res = new BigInteger();
            BigInteger temp = new BigInteger();
            for (int i = 0; i < a.list.Count(); )
            {
                temp.list.Add(a.list[i]);
                i++;
                while (i < a.list.Count() && compare(temp, b) == -1)
                {
                    temp.list.Add(a.list[i++]);
                    res.list.Add((char)('0' - 48));
                }
                int n = 0;
                while (compare(temp, b) != -1)
                {
                    temp = minus(temp, b);
                    n++;
                }
                if (n > 0)
                {
                    res.list.Add((char)n);
                }
                else
                    res.list.Add((char)0);
            }

                return res;
        }
    }
}
