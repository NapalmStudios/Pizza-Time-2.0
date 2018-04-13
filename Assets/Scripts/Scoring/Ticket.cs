using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PizzaTime;

namespace PizzaTime
{
    public enum TicketType
    {
        IsCheese,
        IsSingle,
        IsDouble,
        IsTripple
    }

    public class Ticket : MonoBehaviour
    {
        public TicketType ticketType;
        public bool isActive;
        public float ticketTime;
        public float tipTime;
        public int ticketWorth;
        public int dirtyNeg;
        public Material pizzaMat;

        private void Start()
        {
            isActive = true;
        }

        private void Update()
        {
            TipTiming();
        }

        private void TipTiming()
        {
            if (tipTime > 0)
            {
                tipTime -= Time.deltaTime;
            }

            if (tipTime < 0)
            {
                tipTime = 0;
            }

            if (ticketTime > 0)
            {
                ticketTime -= Time.deltaTime;
            }

            if (ticketTime <= 0)
            {
                isActive = false;
            }
        }
    }
}