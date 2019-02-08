using System;
using System.Collections.Generic;
using System.Text;

namespace project1
{
    class Player
    {
        public string name { get; set; }
        public int salary { get; set; }
        public string school { get; set; }
        public string position { get; set; }
        public int rank { get; set; }
        public bool selected { get; set; }

        public Player(string _name, int _salary, string _school, string _position, int _rank)
        {
            name = _name;
            salary = _salary;
            school = _school;
            position = _position;
            rank = _rank;
            selected = false;
        }

        public bool isSelected()
        {
            return selected;
        }
        public void selectPlayer()
        {
            selected = true;
        }
    }
}
