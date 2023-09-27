using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IPV4Translator
{
    public class LeoIPAddress
    {
        private byte[] address = new byte[4];
        private byte[] subnetMask = new byte[4];
        private byte[] broadcast = new byte[4];
        private byte[] networkID = new byte[4];
        private string subnet = "";
        //Constructor
        public LeoIPAddress(string ipAddress)
        {
            //Turn into bytes
            string[] subnetSplit = ipAddress.Split("/");
            string[] ipSplit = subnetSplit[0].Split('.');
            subnet = subnetSplit[1];
            
            //Calculate Subnet, NetworkID, and Broadcast Address
            int subnetBits = 32 - Convert.ToInt32(subnetSplit[1]);
            uint subnetMaskVal = (uint)(0xFFFFFFFF << subnetBits);
            for(int i = 0; i < 4; i++)
            {
                //store address
                address[i] = Convert.ToByte(ipSplit[i]);

                //set Subnetmask 
                subnetMask[i] = (byte)(subnetMaskVal >> (8 * i));

                //set NetworkID with bitwise operation of &
                networkID[i] = (byte)(address[i] & subnetMask[i]);

                //set Broadcast with a bitwise OR and Negation ( | ) ( ~ ), Subnetmask is used in inverse for calculating broadcast address
                broadcast[i] = (byte)(networkID[i] | ~subnetMask[i]);
            }
        }

        //To read easily
        public string Address()
        {
            byte[] prop = address;
            return $"{prop[0]}.{prop[1]}.{prop[2]}.{prop[3]}/{subnet}";
        }
        public string SubnetMask()
        {
            byte[] prop = subnetMask;
            return $"{prop[0]}.{prop[1]}.{prop[2]}.{prop[3]}";
        }
        public string Broadcast()
        {
            byte[] prop = broadcast;
            return $"{prop[0]}.{prop[1]}.{prop[2]}.{prop[3]}";
        }
        public string NetworkID()
        {
            byte[] prop = networkID;
            return $"{prop[0]}.{prop[1]}.{prop[2]}.{prop[3]}";
        }
        public string Range()
        {
            return $"{NetworkID()} - {Broadcast()}";
        }

        //Compare
        public bool IsSameNetwork(LeoIPAddress foreign)
        {
            return foreign.Address() == this.Address();
        }
    }
}
