using static System.Formats.Asn1.AsnWriter;
using System.Net.NetworkInformation;
using System.Runtime.Intrinsics.X86;
using System;

namespace LeoQueue
{
    public class leoProgram
    {
        static void Main(string[] args)
        {
            Queue<int> callerIds = new Queue<int>();

            //Add some Ids
            callerIds.Enqueue(101);
            callerIds.Enqueue(102);
            callerIds.Enqueue(103);
            callerIds.Enqueue(104);
            callerIds.Enqueue(105);
            callerIds.Enqueue(106);

            Console.WriteLine("Caller IDs in the queue:");

            //Iterate over the queue (foreach) and display the caller Ids
            foreach(int callId in callerIds)
            {
                Console.WriteLine($"CallerId : {callId}");
            }
        }

        public string IterateQueue(Queue<int> callerIds)
        {
            string result = "Caller IDs in the queue:\n";

            foreach (int callerId in callerIds)
            {
                result += $"Caller ID: {callerId}\n";
            }
            return result;
        }

        //Using System: Import the System namespace to gain access to the necessary classes and functions for input/output operations.​

        //Create a Queue Object: Instantiate a Queue<int> object called callerIds to store the caller IDs.​

        //Enqueue Caller IDs: Use the Enqueue method of the callerIds object to add caller IDs to the end of the queue.​

        //Iterate Over the Queue: Use a foreach loop to iterate over the elements in the callerIds queue and display them using the Console.WriteLine method.​

        //Run the Program: Execute the program and observe the output as caller IDs are enqueued and displayed from the queue.​



    }
}