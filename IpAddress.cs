using System;

namespace CustomClasses
{
    public class IpAddress : IComparable<IpAddress>
    {
        private int[] addresses = new int[4];
        private String name;
        public String Name 
        {
            get 
            {
                return this.name;
            }
            set 
            {
                this.name = value;
                this.lastRenewed = DateTime.Now;
            }
        }
        private DateTime lastRenewed;

        public DateTime LastRenewed
        {
            get {
                return lastRenewed;
            }
        }

        public String Address {
            get {
                String ipString = "";
                for(int i = 0; i < this.addresses.Length; i++)
                {
                    var toAppend = this.addresses[i].ToString();
                    if(i != this.addresses.Length - 1)
                    {
                        toAppend += ".";
                    }
                    ipString += toAppend;
                }
                return ipString;
            }
        }

        public IpAddress(String address)
        {
            address = address.Trim();
            var charArr = address.Split('.');
            if(charArr.Length != 4)
            {
                throw new IpAddressException($"Expected array size of 4. Received array size of {charArr.Length}");
            }
            for(int i = 0; i < charArr.Length; i++)
            {
                if(int.TryParse(charArr[i], out int res))
                {
                    if(res < 0 || res > 255)
                    {
                        throw new IpAddressException($"Invalid IP Address format. Problem section: {res}");
                    }
                    this.addresses[i] = res;
                }
            }
            this.Name = "Device";
        }
        public IpAddress(String address, String name) : this(address)
        {
            this.Name = name;
        }

        public int CompareTo(IpAddress address2)
        {
            if(address2 == null)
            {
                return 1;
            }
            else
            {
                for(int i = 0; i < this.addresses.Length; i++)
                {
                    if(this.addresses[i] > address2.addresses[i])
                    {
                        return 1;
                    }
                    else if(this.addresses[i] < address2.addresses[i])
                    {
                        return -1;
                    }
                }
                return 0;
            }
        }
    
        public static bool operator > (IpAddress one, IpAddress two)
        {
            return one.CompareTo(two) == 1;
        }

        public static bool operator < (IpAddress one, IpAddress two)
        {
            return one.CompareTo(two) == -1;
        }

        public static bool operator >= (IpAddress one, IpAddress two)
        {
            return one.CompareTo(two) >= 0;
        }

        public static bool operator <= (IpAddress one, IpAddress two)
        {
            return one.CompareTo(two) <= 0;
        }

        public override string ToString()
        {
            return $"{this.Address} : {this.Name} -- Modified {this.lastRenewed.ToShortDateString()} at {this.lastRenewed.ToShortTimeString()}";
        }

        public override bool Equals(object obj)
        {
            if(obj == null || obj.GetType() != typeof(IpAddress))
            {
                return false;
            }
            else
            {
                var that = (IpAddress) obj;
                return this.CompareTo(that) == 0;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class IpAddressException : Exception
    {
        public IpAddressException(String message) : base(message)
        {
            
        }
    }
}