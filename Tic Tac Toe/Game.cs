using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe {
    public partial class Game : Form {
        Button[] _buttons;
        bool _isOPlay = true;
        int _numOfMoves = 0;

        Color _winColor = Color.Green;
        Color _defaultColor = Color.FromArgb(162, 123, 92);
        public Game() {
            InitializeComponent();
            _Init_();
        }

        private void _Init_() {
            _buttons = new Button[9] {
                A1 ,A2, A3,
                B1, B2, B3,
                C1, C2, C3
            };

            foreach(Button _button in _buttons) {
                _button.Click += ButtonFunctionality;
                _button.BackColor = _defaultColor;
            }
        }

        private void ButtonFunctionality(object sender, EventArgs e) {
            Button btn = (Button) sender;
            if (btn.Text != "")
                return;

            _numOfMoves++;
            NumberOfMoves.Text = _numOfMoves.ToString();

            CurrentMove.Text = _isOPlay ? "X" : "O";
            btn.Text = _isOPlay ? "O" : "X";
            btn.Enabled = false;

            _isOPlay = !_isOPlay;

            if (CheckWin()) {
                MessageBox.Show($"{btn.Text} won the game!");
                ResetGame();
                return;
            }

            if (_numOfMoves >= 9) {
                MessageBox.Show($"Draw!");
                ResetGame();
                return;
            }
        } 

        private bool CheckWin() {
            //Horizontal
            if (A1.Text == A2.Text && A2.Text == A3.Text && !A1.Enabled) {
                A1.BackColor = _winColor;
                A2.BackColor = _winColor;
                A3.BackColor = _winColor;
                return true;
            }
            else if (B1.Text == B2.Text && B2.Text == B3.Text && !B1.Enabled) {
                B1.BackColor = _winColor;
                B2.BackColor = _winColor;
                B3.BackColor = _winColor;
                return true;
            }
            else if (C1.Text == C2.Text && C2.Text == C3.Text && !C1.Enabled) {
                C1.BackColor = _winColor;
                C2.BackColor = _winColor;
                C3.BackColor = _winColor;
                return true;
            }

            //Vertical
            else if (A1.Text == B1.Text && B1.Text == C1.Text && !A1.Enabled) {
                A1.BackColor = _winColor;
                B1.BackColor = _winColor;
                C1.BackColor = _winColor;
                return true;
            }
            else if (A2.Text == B2.Text && B2.Text == C2.Text && !A2.Enabled) {
                A2.BackColor = _winColor;
                B2.BackColor = _winColor;
                C2.BackColor = _winColor;
                return true;
            }
            else if (A3.Text == B3.Text && B3.Text == C3.Text && !A3.Enabled) {
                A3.BackColor = _winColor;
                B3.BackColor = _winColor;
                C3.BackColor = _winColor;
                return true;
            }

            //Cross
            else if (A1.Text == B2.Text && B2.Text == C3.Text && !A1.Enabled) {
                A1.BackColor = _winColor;
                B2.BackColor = _winColor;
                C3.BackColor = _winColor;
                return true;
            }
            else if (A3.Text == B2.Text && B2.Text == C1.Text && !A3.Enabled) {
                A3.BackColor = _winColor;
                B2.BackColor = _winColor;
                C1.BackColor = _winColor;
                return true;
            }

            return false;
        }

        private void ResetGame() {
            foreach (Button _button in _buttons) {
                _button.Text = "";
                _button.Enabled = true;
                _button.BackColor = _defaultColor;
            }
            _numOfMoves = 0;
            NumberOfMoves.Text = _numOfMoves.ToString();
        }
    }
}
