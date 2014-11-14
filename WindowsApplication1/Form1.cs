//********************************************
// Author: Davy Whelan
// Login Number: C00153355
// Creation Date: 14/12/12
//********************************************
// Program Description:
//Robocode clone
//********************************************
// Known Issues:
// A little rushed help menu, art didn't get a final pass, otherwise I think I'm good.
//********************************************
// Added Features/Improvements:
//Powerups
//High scores
//Multi-direction shooting, no longer have to be facing a direction to shoot
//HUD and health bars


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace WindowsApplication1
{

    public partial class Form1 : Form
    {
    
        //Borderless window movement (Found online, but it works)
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //ENTITY NUMBERS
        //0  Zerogouki
        //1  Shogouki
        //10 Sachiel
        //11 Israfel Kou
        //12 Israfel Otsu
        //21 Ramiel

        //All the variables that describe the position of the player
        //i.e. its position, its width and height, and how much it can move left and right
        float playerPosX;
        float playerPosY;
        float playerWidthDefault;
        float playerHeightDefault;
        float playerWidth;
        float playerHeight;
        int playerMoveX;
        int playerMoveY;
        int playerSpeedDefault;
        int playerSpeed;
        int playerDir;
        int playerMoveDir;
        int playerHealthTotal;
        int playerHealth;
        int playerLives;
        int playerBombs;
        int playerScore;
        bool playerCanMove;
        bool playerCanShoot;
        bool playerCanHurt;
        bool playerCanScore;
        bool playerPUInvuln;
        bool playerPUSpeed;
        bool playerPUShrink;
        bool playerAlive;


        //All the variables that describe the position of the beam
        //i.e. its position, and if it is alive or not.
        //if beamAlive is true, then the beam is drawn to the screen and moved
        //otherwise it is not
        float beamPosX;
        float beamPosY;
        float beamWidthDefault;
        float beamWidth;
        float beamLength;
        int beamDir;
        int beamSpeedDefault;
        int beamSpeed;
        int beamDamageDefault;
        int beamDamage;
        bool beamPUWide;
        bool beamPUFast;
        bool beamPUDamage;
        bool beamAlive;

        //Enemy Vars
        //Zerogouki
        float zerogoukiWidth;
        float zerogoukiHeight;
        float zerogoukiPosX;
        float zerogoukiPosY;
        int zerogoukiMoveY;
        int zerogoukiMoveX;
        int zerogoukiSpeed;
        int zerogoukiDir;
        int zerogoukiHealthTotal;
        int zerogoukiHealth;
        int zerogoukiDamage;
        bool zerogoukiAlive;
        bool zerogoukiCanMove;
        //Shogouki
        float shogoukiWidth;
        float shogoukiHeight;
        float shogoukiPosX;
        float shogoukiPosY;
        int shogoukiMoveY;
        int shogoukiMoveX;
        int shogoukiSpeed;
        int shogoukiHealthTotal;
        int shogoukiHealth;
        int shogoukiDamage;
        bool shogoukiAlive;
        bool shogoukiCanMove;
        //Hostages
        //Sachiel
        float sachielWidth;
        float sachielHeight;
        float sachielPosX;
        float sachielPosY;
        int sachielMoveX;
        int sachielMoveY;
        int sachielSpeed;
        int sachielDir;
        int sachielHealthTotal;
        int sachielHealth;
        bool sachielAlive;
        //Israfel
        int israfelDir;
        //Kou
        float kouWidth;
        float kouHeight;
        float kouPosX;
        float kouPosY;
        int kouMoveX;
        int kouMoveY;
        int kouSpeed;
        int kouDir;
        int kouHealthTotal;
        int kouHealth;
        bool kouAlive;
        //Otsu
        float otsuWidth;
        float otsuHeight;
        float otsuPosX;
        float otsuPosY;
        int otsuMoveX;
        int otsuMoveY;
        int otsuSpeed;
        int otsuDir;
        int otsuHealthTotal;
        int otsuHealth;
        bool otsuAlive;

        //pens
        Pen pBlack;
        SolidBrush bBlack;
        SolidBrush bWhite;
        Pen pCyan;
        SolidBrush bCyan;
        Pen pBlue;
        SolidBrush bBlue;
        Pen pViolet;
        SolidBrush bViolet;
        Pen pCrimson;
        SolidBrush bIndigo;
        Pen pIndigo;
        Pen pOrange;
        Pen pWhite;
        SolidBrush bRed;
        SolidBrush bDGreen;
        Pen pPurple;
        Pen pLime;
        Pen pSGrey;
        SolidBrush bDRed;
        SolidBrush bDSGrey;
        Pen pCream;
        Pen pSilver;
        SolidBrush bDGrey;
        SolidBrush bBone;
        Pen pSteel;
        SolidBrush bYellow;
        SolidBrush bThistle;

        //Random object used to create random position for the enemy
        Random r;
        //debug menu
        bool debug = false;
        bool gameOver = true;
        int hiscore;
    

        public Form1()
        {

            InitializeComponent();
            //automatic double buffering
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

            //instantiate the random object
            r = new Random();

            //Ramiel
            //initialise all the variables of the player
            playerWidthDefault = 60;
            playerHeightDefault = 60;
            playerWidth = playerWidthDefault;
            playerHeight = playerHeightDefault;
            playerPosX = (this.Width / 2) - (playerWidth / 2);
            playerPosY = this.Height - (playerHeight * 2);
            playerMoveX = 0;
            playerMoveY = 0;
            playerSpeedDefault = 2;
            playerSpeed = playerSpeedDefault;
            playerDir = 1;
            playerMoveDir = 1;
            playerHealthTotal = 3;
            playerHealth = playerHealthTotal;
            playerLives = 3;
            playerBombs = 0;
            playerCanMove = true;
            playerCanShoot = true;
            playerCanHurt = true;
            playerCanScore = true;
            playerPUInvuln = false;
            playerPUSpeed = false;
            playerPUShrink = false;
            playerAlive = true;

            //Beam
            //initialise beam variables
            beamAlive = false;
            beamWidthDefault = 16;
            beamWidth = beamWidthDefault;
            beamLength = 16;
            beamSpeedDefault = 5;
            beamSpeed = beamSpeedDefault;
            beamDamageDefault = 1;
            beamDamage = beamDamageDefault;
            beamPUWide = false;
            beamPUFast = false;
            beamPUDamage = false;
            //Enemies
            //Unit 00
            zerogoukiWidth = 20;
            zerogoukiHeight = 20;
            zerogoukiPosX = 0;
            zerogoukiPosY = 0;
            zerogoukiMoveY = 0;
            zerogoukiMoveX = 0;
            zerogoukiSpeed = 1;
            zerogoukiDir = 1;
            zerogoukiHealthTotal = 2;
            zerogoukiHealth = zerogoukiHealthTotal;
            zerogoukiDamage = 1;
            zerogoukiAlive = false;
            //Unit 01
            shogoukiWidth = 20;
            shogoukiHeight = 20;
            shogoukiPosX = 0;
            shogoukiPosY = 0;
            shogoukiMoveY = 0;
            shogoukiMoveX = 0;
            shogoukiSpeed = 1;
            shogoukiHealthTotal = 3;
            shogoukiHealth = shogoukiHealthTotal;
            shogoukiDamage = 1;
            shogoukiAlive = false;
            //Hostages
            //Sachiel
            sachielWidth = 20;
            sachielHeight = 20;
            sachielPosX = 0;
            sachielPosY = 0;
            sachielMoveX = 0;
            sachielMoveY = 0;
            sachielSpeed = 1;
            sachielDir = 1;
            sachielHealthTotal = 2;
            sachielHealth = sachielHealthTotal;
            sachielAlive = false;
            //Hostages
            //Israfel
            israfelDir = 1;
            //Kou
            kouWidth = 20;
            kouHeight = 20;
            kouPosX = 0;
            kouPosY = 0;
            kouMoveX = 0;
            kouMoveY = 0;
            kouSpeed = 1;
            kouDir = israfelDir;
            kouHealthTotal = 1;
            kouHealth = kouHealthTotal;
            kouAlive = false;
            //Otsu
            otsuWidth = 20;
            otsuHeight = 20;
            otsuPosX = 0;
            otsuPosY = 0;
            otsuMoveX = 0;
            otsuMoveY = 0;
            otsuSpeed = 1;
            otsuDir = israfelDir;
            otsuHealthTotal = 1;
            otsuHealth = otsuHealthTotal;
            otsuAlive = false;

            //create pens
            //Black
            pBlack = new Pen(Color.Black);
            bBlack = new SolidBrush(Color.Black);
            bWhite = new SolidBrush(Color.White);
            //Ramiel
            pCyan = new Pen(Color.Cyan);
            bCyan = new SolidBrush(Color.Cyan);
            pBlue = new Pen(Color.RoyalBlue);
            bBlue = new SolidBrush(Color.RoyalBlue);
            pWhite = new Pen(Color.White);
            pCrimson = new Pen(Color.Crimson);
            pIndigo = new Pen(Color.Indigo);
            bIndigo = new SolidBrush(Color.Indigo);
            //Beam
            pViolet = new Pen(Color.MediumVioletRed);
            bViolet = new SolidBrush(Color.MediumVioletRed);
            //Unit 00
            pOrange = new Pen(Color.Orange);
            //Unit 01
            pPurple = new Pen(Color.BlueViolet);
            pLime = new Pen(Color.Lime);
            bRed = new SolidBrush(Color.Red);
            //Sachiel
            bDSGrey = new SolidBrush(Color.DarkSlateGray);
            pSGrey = new Pen(Color.SlateGray);
            bDRed = new SolidBrush(Color.DarkRed);
            bDGreen = new SolidBrush(Color.DarkGreen);
            pCream = new Pen(Color.White);
            //Israfel            
            pSilver = new Pen(Color.Silver);
            bYellow = new SolidBrush(Color.Goldenrod);
            bThistle = new SolidBrush(Color.Thistle);
            bBone = new SolidBrush(Color.BurlyWood);
            //pSilver
            pSteel = new Pen(Color.SteelBlue);
            bDGrey = new SolidBrush(Color.DimGray);

            hiscore = 1000;
        }

        //On Form load
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Calls various draw methods
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (gameOver == false)
            {
                //Debug: Indicates when game is in debug mode
                if (debug == true)
                {
                    g.DrawRectangle(pCyan, 0, 0, this.Width - 1, this.Height - 1);
                }

                //Sachiel
                if (sachielAlive == true)
                {
                    DrawHostage(g, 10);
                }
                //Israfel
                //Kou
                if (kouAlive == true)
                {
                    DrawHostage(g, 11);
                }
                //Otsu
                if (otsuAlive == true)
                {
                    DrawHostage(g, 12);
                }

                //Beam
                //only if bulletAlive is true, is it drawn to the screen

                if (beamAlive == true)
                {
                    if (beamDir == 1)
                    {
                        DrawBeam(g, 1);
                    }

                    if (beamDir == 2)
                    {
                        DrawBeam(g, 2);
                    }

                    if (beamDir == 3)
                    {
                        DrawBeam(g, 3);
                    }

                    if (beamDir == 4)
                    {
                        DrawBeam(g, 4);
                    }
                }

                //Ramiel
                if (playerAlive == true)
                {
                    DrawPlayer(g);
                }
                //Zerogouki
                if (zerogoukiAlive == true)
                {
                    DrawEnemy(g, 0);
                }
                //Shogouki
                if (shogoukiAlive == true)
                {
                    DrawEnemy(g, 1);
                }
            }

            DrawHUD(g);
        }
        
        //Draws passed Hostages
        private void DrawHostage(Graphics g, int hostageNum)
        {
            if (hostageNum == 10)
            {
                g.FillRectangle(bDSGrey, sachielPosX, sachielPosY, sachielWidth, sachielHeight);
                g.DrawRectangle(pSGrey, sachielPosX, sachielPosY, sachielWidth, sachielHeight);
                g.DrawRectangle(pSteel, sachielPosX + ((sachielWidth / 8) * 3), sachielPosY + ((sachielHeight / 5) * 3), sachielWidth / 4, sachielHeight / 4);
                g.DrawRectangle(pCream, sachielPosX + (sachielWidth / 4), sachielPosY + (sachielHeight / 8) / 2, sachielWidth / 4, sachielHeight / 4);
                g.DrawRectangle(pCream, sachielPosX + (sachielWidth / 4) * 2, sachielPosY + (sachielHeight / 8) / 2, sachielWidth / 4, sachielHeight / 4);
                g.FillEllipse(bDRed, sachielPosX + ((sachielWidth / 8) * 3), sachielPosY + ((sachielHeight / 5) * 3), sachielWidth / 4, sachielHeight / 4);

                //Health bar
                g.FillRectangle(bDGrey, (sachielPosX + sachielWidth / 2) - (sachielHealthTotal * 10) / 2 + 1, sachielPosY - 10, (sachielHealthTotal * 10), 5);
                g.FillRectangle(bDGreen, (sachielPosX + sachielWidth / 2) - (sachielHealthTotal * 10) / 2 + 1, sachielPosY - 10, (sachielHealth * 10), 5);
            }

            if (hostageNum == 11)
            {
                g.FillRectangle(bYellow, kouPosX, kouPosY, kouWidth, kouHeight);
                g.DrawRectangle(pSilver, kouPosX, kouPosY, kouWidth, kouHeight);

                //Health bar
                g.FillRectangle(bDGrey, (kouPosX + kouWidth / 2) - (kouHealthTotal * 10) / 2 + 1, kouPosY - 10, (kouHealthTotal * 10), 5);
                g.FillRectangle(bDGreen, (kouPosX + kouWidth / 2) - (kouHealthTotal * 10) / 2 + 1, kouPosY - 10, (kouHealth * 10), 5);
            }

            if (hostageNum == 12)
            {
                g.FillRectangle(bThistle, otsuPosX, otsuPosY, otsuWidth, otsuHeight);
                g.DrawRectangle(pSilver, otsuPosX, otsuPosY, otsuWidth, otsuHeight);

                //Health bar
                g.FillRectangle(bDGrey, (otsuPosX + otsuWidth / 2) - (otsuHealthTotal * 10) / 2 + 1, otsuPosY - 10, (otsuHealthTotal * 10), 5);
                g.FillRectangle(bDGreen, (otsuPosX + otsuWidth / 2) - (otsuHealthTotal * 10) / 2 + 1, otsuPosY - 10, (otsuHealth * 10), 5);
            }
        }

        //Draws passedBeam
        private void DrawBeam(Graphics g, int beamDir)
        {

            if (beamPUDamage == true)
            {
                bViolet.Color = Color.White;
                bIndigo.Color = Color.Cyan;
            }
            else
            {
                bViolet.Color = Color.MediumVioletRed;
                bIndigo.Color = Color.Indigo;
            }

            if (beamDir == 1)
            {
                g.FillRectangle(bIndigo, beamPosX, beamPosY, beamWidth, beamLength);
                g.DrawRectangle(pViolet, beamPosX, beamPosY, beamWidth, beamLength);
                //trail
                g.FillRectangle(bWhite, beamPosX + beamWidth / 4, beamPosY + beamLength / 4, beamWidth / 2, beamLength / 2);
                g.FillRectangle(bViolet, beamPosX + beamWidth / 4, beamPosY + beamLength, beamWidth / 2, ((beamLength / 4) * 3));
                g.FillRectangle(bViolet, beamPosX + beamWidth / 4, beamPosY + ((beamLength / 4) * 8), beamWidth / 2, beamLength / 4);
                g.DrawRectangle(pCrimson, beamPosX + beamWidth / 4, beamPosY + beamLength / 4, beamWidth / 2, beamLength / 2);
                g.DrawRectangle(pCrimson, beamPosX + beamWidth / 4, beamPosY + beamLength, beamWidth / 2, ((beamLength / 4) * 3));
                g.DrawRectangle(pCrimson, beamPosX + beamWidth / 4, beamPosY + ((beamLength / 4) * 8), beamWidth / 2, beamLength / 4);
            }

            if (beamDir == 2)
            {
                g.FillRectangle(bIndigo, beamPosX, beamPosY, beamLength, beamWidth);
                g.DrawRectangle(pViolet, beamPosX, beamPosY, beamLength, beamWidth);
                //trail
                g.FillRectangle(bWhite, beamPosX + beamLength / 4, beamPosY + beamWidth / 4, beamLength / 2, beamWidth / 2);
                g.FillRectangle(bViolet, beamPosX - ((beamLength / 4) * 3), beamPosY + (beamWidth / 4), ((beamLength / 4) * 3), beamWidth / 2);
                g.FillRectangle(bViolet, beamPosX - ((beamLength / 4) * 5), beamPosY + (beamWidth / 4), beamLength / 4, beamWidth / 2);
                g.DrawRectangle(pCrimson, beamPosX + beamLength / 4, beamPosY + beamWidth / 4, beamLength / 2, beamWidth / 2);
                g.DrawRectangle(pCrimson, beamPosX - ((beamLength / 4) * 3), beamPosY + (beamWidth / 4), ((beamLength / 4) * 3), beamWidth / 2);
                g.DrawRectangle(pCrimson, beamPosX - ((beamLength / 4) * 5), beamPosY + (beamWidth / 4), beamLength / 4, beamWidth / 2);
            }

            if (beamDir == 3)
            {
                g.FillRectangle(bIndigo, beamPosX, beamPosY, beamWidth, beamLength);
                g.DrawRectangle(pViolet, beamPosX, beamPosY, beamWidth, beamLength);
                //trail
                g.FillRectangle(bWhite, beamPosX + beamWidth / 4, beamPosY + beamLength / 4, beamWidth / 2, beamLength / 2);
                g.FillRectangle(bViolet, beamPosX + beamWidth / 4, beamPosY - ((beamLength / 4) * 3), beamWidth / 2, ((beamLength / 4) * 3));
                g.FillRectangle(bViolet, beamPosX + beamWidth / 4, beamPosY - ((beamLength / 4) * 5), beamWidth / 2, beamLength / 4);
                g.DrawRectangle(pCrimson, beamPosX + beamWidth / 4, beamPosY + beamLength / 4, beamWidth / 2, beamLength / 2);
                g.DrawRectangle(pCrimson, beamPosX + beamWidth / 4, beamPosY - ((beamLength / 4) * 3), beamWidth / 2, ((beamLength / 4) * 3));
                g.DrawRectangle(pCrimson, beamPosX + beamWidth / 4, beamPosY - ((beamLength / 4) * 5), beamWidth / 2, beamLength / 4);
            }

            if (beamDir == 4)
            {
                g.FillRectangle(bIndigo, beamPosX, beamPosY, beamLength, beamWidth);
                g.DrawRectangle(pViolet, beamPosX, beamPosY, beamLength, beamWidth);
                //trail
                g.FillRectangle(bWhite, beamPosX + beamLength / 4, beamPosY + beamWidth / 4, beamLength / 2, beamWidth / 2);
                g.FillRectangle(bViolet, beamPosX + beamLength, beamPosY + (beamWidth / 4), ((beamLength / 4) * 3), beamWidth / 2);
                g.FillRectangle(bViolet, beamPosX + ((beamLength / 4) * 8), beamPosY + (beamWidth / 4), beamLength / 4, beamWidth / 2);
                g.DrawRectangle(pCrimson, beamPosX + beamLength / 4, beamPosY + beamWidth / 4, beamLength / 2, beamWidth / 2);
                g.DrawRectangle(pCrimson, beamPosX + beamLength, beamPosY + (beamWidth / 4), ((beamLength / 4) * 3), beamWidth / 2);
                g.DrawRectangle(pCrimson, beamPosX + ((beamLength / 4) * 8), beamPosY + (beamWidth / 4), beamLength / 4, beamWidth / 2);
            }
        }

        //Draws Player
        private void DrawPlayer(Graphics g)
        {
            if (playerPUShrink == true)
            {
                playerHeight = playerHeightDefault / 2;
                playerWidth = playerWidthDefault / 2;
            }

            else if (playerPUShrink == false)
            {
                playerHeight = playerHeightDefault;
                playerWidth = playerWidthDefault;
            }

            //draw a rectangle representing the player at position (xPos,yPos)
            if (playerPUInvuln == true)
            {
                g.FillRectangle(bCyan, playerPosX, playerPosY, playerWidth, playerHeight);
            }
            else
            {
                g.FillRectangle(bBlue, playerPosX, playerPosY, playerWidth, playerHeight);
            }

            if (playerCanHurt == false)
            {
                g.DrawRectangle(pWhite, playerPosX, playerPosY, playerWidth, playerHeight);
            }
            else
            {
                g.DrawRectangle(pCyan, playerPosX, playerPosY, playerWidth, playerHeight);
            }
            //Facing direction
            if (playerDir == 1)
            {
                g.DrawLine(pCrimson, playerPosX + ((playerWidth / 8) * 3), playerPosY, playerPosX + ((playerWidth / 8) * 5), playerPosY);
                g.DrawLine(pWhite, playerPosX + ((playerWidth / 8) * 3), playerPosY, playerPosX + playerWidth / 2, playerPosY + playerHeight / 2);
                g.DrawLine(pWhite, playerPosX + ((playerWidth / 8) * 5), playerPosY, playerPosX + playerWidth / 2, playerPosY + playerHeight / 2);
            }

            if (playerDir == 2)
            {
                g.DrawLine(pCrimson, playerPosX + playerWidth, playerPosY + ((playerHeight / 8) * 3), playerPosX + playerWidth, playerPosY + ((playerHeight / 8) * 5));
                g.DrawLine(pWhite, playerPosX + playerWidth, playerPosY + ((playerHeight / 8) * 3), playerPosX + playerWidth / 2, playerPosY + playerHeight / 2);
                g.DrawLine(pWhite, playerPosX + playerWidth, playerPosY + ((playerHeight / 8) * 5), playerPosX + playerWidth / 2, playerPosY + playerHeight / 2);
            }

            if (playerDir == 3)
            {
                g.DrawLine(pCrimson, playerPosX + ((playerWidth / 8) * 3), playerPosY + playerHeight, playerPosX + ((playerWidth / 8) * 5), playerPosY + playerHeight);
                g.DrawLine(pWhite, playerPosX + ((playerWidth / 8) * 3), playerPosY + playerHeight, playerPosX + playerWidth / 2, playerPosY + playerHeight / 2);
                g.DrawLine(pWhite, playerPosX + ((playerWidth / 8) * 5), playerPosY + playerHeight, playerPosX + playerWidth / 2, playerPosY + playerHeight / 2);
            }

            if (playerDir == 4)
            {
                g.DrawLine(pCrimson, playerPosX, playerPosY + ((playerHeight / 8) * 3), playerPosX, playerPosY + ((playerHeight / 8) * 5));
                g.DrawLine(pWhite, playerPosX, playerPosY + ((playerHeight / 8) * 3), playerPosX + playerWidth / 2, playerPosY + playerHeight / 2);
                g.DrawLine(pWhite, playerPosX, playerPosY + ((playerHeight / 8) * 5), playerPosX + playerWidth / 2, playerPosY + playerHeight / 2);
            }
            //Core
            g.FillEllipse(bDRed, playerPosX + ((playerWidth / 8) * 3), playerPosY + ((playerHeight / 8) * 3), playerWidth / 4, playerHeight / 4);
            //Vertices
            if (playerPUInvuln == true)
            {
                g.DrawLine(pBlue, playerPosX, playerPosY, playerPosX + playerWidth, playerPosY + playerHeight);
                g.DrawLine(pBlue, playerPosX + playerWidth, playerPosY, playerPosX, playerPosY + playerHeight);
            }
            else
            {
                g.DrawLine(pCyan, playerPosX, playerPosY, playerPosX + playerWidth, playerPosY + playerHeight);
                g.DrawLine(pCyan, playerPosX + playerWidth, playerPosY, playerPosX, playerPosY + playerHeight);
            }
        }

        //Draws passed Enemy
        private void DrawEnemy(Graphics g, int enemyNum)
        {

            if (enemyNum == 0)
            {
                g.DrawRectangle(pOrange, zerogoukiPosX, zerogoukiPosY, zerogoukiWidth, zerogoukiHeight);
                g.DrawRectangle(pWhite, zerogoukiPosX + zerogoukiWidth / 4, zerogoukiPosY + zerogoukiHeight / 4, zerogoukiWidth / 2, zerogoukiHeight / 2);


                //Health bar
                g.FillRectangle(bDGrey, (zerogoukiPosX + zerogoukiWidth / 2) - (zerogoukiHealthTotal * 10) / 2, zerogoukiPosY - 10, (zerogoukiHealthTotal * 10), 5);
                g.FillRectangle(bDRed, (zerogoukiPosX + zerogoukiWidth / 2) - (zerogoukiHealthTotal * 10) / 2, zerogoukiPosY - 10, (zerogoukiHealth * 10), 5);
            }

            if (enemyNum == 1)
            {
                g.FillRectangle(bBlack, shogoukiPosX, shogoukiPosY, shogoukiWidth, shogoukiHeight);
                g.DrawRectangle(pPurple, shogoukiPosX, shogoukiPosY, shogoukiWidth, shogoukiHeight);

                if (shogoukiHealth <= 1)
                {
                    g.FillRectangle(bRed, shogoukiPosX + ((shogoukiWidth / 8) * 3), shogoukiPosY + ((shogoukiHeight / 8) * 3), shogoukiWidth / 4, shogoukiHeight / 4);
                }
                g.DrawRectangle(pLime, shogoukiPosX + shogoukiWidth / 4, shogoukiPosY + shogoukiHeight / 4, shogoukiWidth / 2, shogoukiHeight / 2);

                //Health bar
                g.FillRectangle(bDGrey, (shogoukiPosX + shogoukiWidth / 2) - (shogoukiHealthTotal * 10) / 2, shogoukiPosY - 10, (shogoukiHealthTotal * 10), 5);
                g.FillRectangle(bDRed, (shogoukiPosX + shogoukiWidth / 2) - (shogoukiHealthTotal * 10) / 2, shogoukiPosY - 10, (shogoukiHealth * 10), 5);
            }      
        }

        //Draws Heads Up Display
        private void DrawHUD(Graphics g)
        {
            //HUD
            //Lives
            {
                g.FillEllipse(bDGrey, 10, 10, 10, 10);
                g.FillEllipse(bDGrey, 30, 10, 10, 10);
                g.FillEllipse(bDGrey, 50, 10, 10, 10);
                if (playerLives >= 1)
                {
                    g.FillEllipse(bDRed, 10, 10, 10, 10);
                }

                if (playerLives >= 2)
                {
                    g.FillEllipse(bDRed, 30, 10, 10, 10);
                }

                if (playerLives >= 3)
                {
                    g.FillEllipse(bDRed, 50, 10, 10, 10);
                }
            }
            //Health
            {
                g.FillRectangle(bDGrey, 70, 10, playerHealthTotal * 50, 10);
                g.FillRectangle(bDRed, 70, 10, playerHealth * 50, 10);
            }

            //Powerups
            g.FillRectangle(bDGrey, 70, 30, 10, 10);

            //Wide Shot
            //Slot
            g.DrawRectangle(pSteel, 90, 30, 10, 10);
            g.DrawLine(pSteel, 90, 35, 100, 35);
            //Got
            if (beamPUWide == true)
            {
                g.DrawRectangle(pWhite, 90, 30, 10, 10);
                g.DrawLine(pCrimson, 90, 35, 100, 35);
            }
            //Fast Shot
            //Slot
            g.DrawRectangle(pSteel, 110, 30, 10, 10);
            g.DrawLine(pSteel, 115, 30, 115, 40);
            //Got
            if (beamPUFast == true)
            {
                g.DrawRectangle(pWhite, 110, 30, 10, 10);
                g.DrawLine(pViolet, 115, 30, 115, 40);
            }

            //Power Shot
            //Slot
            g.DrawRectangle(pSteel, 130, 30, 10, 10);
            g.DrawRectangle(pSteel, 132, 32, 6, 6);
            //Got
            if (beamPUDamage == true)
            {
                g.DrawRectangle(pWhite, 130, 30, 10, 10);
                g.DrawRectangle(pPurple, 132, 32, 6, 6);
            }

            //Invulnerability
            //Slot
            g.FillEllipse(bDGrey, 152, 32, 6, 6);
            g.DrawRectangle(pSteel, 150, 30, 10, 10);
            //Got
            if (playerPUInvuln == true)
            {
                g.FillEllipse(bDRed, 152, 32, 6, 6);
                g.DrawRectangle(pCyan, 150, 30, 10, 10);
            }

            //Speed
            //Slot
            g.DrawRectangle(pSteel, 170, 30, 10, 10);
            g.DrawLine(pSteel, 175, 30, 170, 40);
            g.DrawLine(pSteel, 175, 30, 180, 40);
            //Got
            if (playerPUSpeed == true)
            {
                g.DrawRectangle(pCyan, 170, 30, 10, 10);
                g.DrawLine(pWhite, 175, 30, 170, 40);
                g.DrawLine(pWhite, 175, 30, 180, 40);
            }

            //Shrink
            //Slot
            g.DrawRectangle(pSteel, 190, 30, 10, 10);
            g.DrawRectangle(pSteel, 192, 32, 6, 6);
            //Got
            if (playerPUShrink == true)
            {
                g.DrawRectangle(pCyan, 190, 30, 10, 10);
                g.DrawRectangle(pWhite, 192, 32, 6, 6);
            }
        }
        
        //Player movement
        private void PlayerMovement()
        {
            //Speed Powerup
            if (playerPUSpeed == true)
            {
                playerSpeed = 4;
            }

            else if (playerPUSpeed == false)
            {
                playerSpeed = playerSpeedDefault;
            }

            //Move the X and Y position by MoveX and MoveY
            playerPosX = playerPosX + playerMoveX;
            playerPosY = playerPosY + playerMoveY;

            //Following four if()s check if Player has exited screen, and loops to the other side
            if (playerPosX > this.Width)
            {
                playerPosX = -playerWidth;
            }

            if (playerPosX < -playerWidth)
            {
                playerPosX = this.Width;
            }

            if (playerPosY < -playerHeight)
            {
                playerPosY = this.Height;
            }

            if (playerPosY > this.Height)
            {
                playerPosY = -playerHeight;
            }

        }

        //Enemy Movement
        private void EnemyMovement()
        {
            //Shogouki
            if (shogoukiAlive == true)
            {
                //Tracks and moves towards Player
                if (shogoukiCanMove == true)
                {
                    if (shogoukiPosX + shogoukiWidth / 2 <= playerPosX + playerWidth / 2)
                    {
                        shogoukiMoveX = shogoukiSpeed;
                        shogoukiPosX = shogoukiPosX + shogoukiMoveX;
                    }

                    if (shogoukiPosX + shogoukiWidth / 2 >= playerPosX + playerWidth / 2)
                    {
                        shogoukiMoveX = -shogoukiSpeed;
                        shogoukiPosX = shogoukiPosX + shogoukiMoveX;
                    }

                    if (shogoukiPosY + shogoukiHeight / 2 <= playerPosY + playerHeight / 2)
                    {
                        shogoukiMoveY = shogoukiSpeed;
                        shogoukiPosY = shogoukiPosY + shogoukiMoveY;
                    }

                    if (shogoukiPosY + shogoukiHeight / 2 >= playerPosY + playerHeight / 2)
                    {
                        shogoukiMoveY = -shogoukiSpeed;
                        shogoukiPosY = shogoukiPosY + shogoukiMoveY;
                    }
                }

                //Following four if()s check if Enemy has exited screen, and loops to the other side
                if (shogoukiPosX > this.Width)
                {
                    shogoukiPosX = -shogoukiWidth;
                }

                if (shogoukiPosX < -shogoukiWidth)
                {
                    shogoukiPosX = this.Width;
                }

                if (shogoukiPosY < -shogoukiHeight)
                {
                    shogoukiPosY = this.Height;
                }

                if (shogoukiPosY > this.Height)
                {
                    shogoukiPosY = -shogoukiHeight;
                }


            }

            //Zerogouki
            if (zerogoukiAlive == true)
            {
                //Enabe direction choosing timer
                tZerogoukiMove.Enabled = true;

                //Move in chosen direction
                if (zerogoukiDir == 1)
                {
                    zerogoukiMoveY = -zerogoukiSpeed;
                    zerogoukiPosY = zerogoukiPosY + zerogoukiMoveY;
                }

                if (zerogoukiDir == 2)
                {
                    zerogoukiMoveX = zerogoukiSpeed;
                    zerogoukiPosX = zerogoukiPosX + zerogoukiMoveX;
                }

                if (zerogoukiDir == 3)
                {
                    zerogoukiMoveY = zerogoukiSpeed;
                    zerogoukiPosY = zerogoukiPosY + zerogoukiMoveY;
                }

                if (zerogoukiDir == 4)
                {
                    zerogoukiMoveX = -zerogoukiSpeed;
                    zerogoukiPosX = zerogoukiPosX + zerogoukiMoveX;
                }

                //Following four if()s check if Enemy has exited screen, and loops to the other side
                if (zerogoukiPosX > this.Width)
                {
                    zerogoukiPosX = -zerogoukiWidth;
                }

                if (zerogoukiPosX < -zerogoukiWidth)
                {
                    zerogoukiPosX = this.Width;
                }

                if (zerogoukiPosY < -zerogoukiHeight)
                {
                    zerogoukiPosY = this.Height;
                }

                if (zerogoukiPosY > this.Height)
                {
                    zerogoukiPosY = -zerogoukiHeight;
                }
            }

            else if (zerogoukiAlive == false)
            {
                //Disable timer if enemy is not alive
                tZerogoukiMove.Enabled = false;
            }
        }

        private void HostageMovement()
        {
            //Sachiel
            if (sachielAlive == true)
            {
                //Enable direction choosing timer
                tSachiel.Enabled = true;

                //Move in chosen direction
                if (sachielDir == 1)
                {
                    sachielMoveY = -sachielSpeed;
                    sachielPosY = sachielPosY + sachielMoveY;
                }

                if (sachielDir == 2)
                {
                    sachielMoveX = sachielSpeed;
                    sachielPosX = sachielPosX + sachielMoveX;
                }

                if (sachielDir == 3)
                {
                    sachielMoveY = sachielSpeed;
                    sachielPosY = sachielPosY + sachielMoveY;
                }

                if (sachielDir == 4)
                {
                    sachielMoveX = -sachielSpeed;
                    sachielPosX = sachielPosX + sachielMoveX;
                }


                //Following four if()s check if Hostage has exited screen, and loops to the other side
                if (sachielPosX > this.Width)
                {
                    sachielPosX = -sachielWidth;
                }

                if (sachielPosX < -sachielWidth)
                {
                    sachielPosX = this.Width;
                }

                if (sachielPosY < -sachielHeight)
                {
                    sachielPosY = this.Height;
                }

                if (sachielPosY > this.Height)
                {
                    sachielPosY = -sachielHeight;
                }
            }

            else if (sachielAlive == false)
            {
                //Disable timer if hostage is not alive
                tSachiel.Enabled = false;
            }

            //Israfel
            if (kouAlive == true || otsuAlive == true)
            {
                
                tIsrafel.Enabled = true;

                //Move in chosen direction
                if (israfelDir == 1)
                {
                    kouMoveY = -kouSpeed;
                    kouPosY = kouPosY + kouMoveY;
                }

                if (israfelDir == 2)
                {
                    kouMoveX = kouSpeed;
                    kouPosX = kouPosX + kouMoveX;
                }

                if (israfelDir == 3)
                {
                    kouMoveY = kouSpeed;
                    kouPosY = kouPosY + kouMoveY;
                }

                if (israfelDir == 4)
                {
                    kouMoveX = -kouSpeed;
                    kouPosX = kouPosX + kouMoveX;
                }

                //Move in chosen direction
                if (israfelDir == 1)
                {
                    otsuMoveY = -otsuSpeed;
                    otsuPosY = otsuPosY + otsuMoveY;
                }

                if (israfelDir == 2)
                {
                    otsuMoveX = otsuSpeed;
                    otsuPosX = otsuPosX + otsuMoveX;
                }

                if (israfelDir == 3)
                {
                    otsuMoveY = otsuSpeed;
                    otsuPosY = otsuPosY + otsuMoveY;
                }

                if (israfelDir == 4)
                {
                    otsuMoveX = -otsuSpeed;
                    otsuPosX = otsuPosX + otsuMoveX;
                }

                //Following four if()s check if Hostage has exited screen, and loops to the other side
                if (kouPosX > this.Width)
                {
                    kouPosX = -kouWidth;
                }

                if (kouPosX < -kouWidth)
                {
                    kouPosX = this.Width;
                }

                if (kouPosY < -kouHeight)
                {
                    kouPosY = this.Height;
                }

                if (kouPosY > this.Height)
                {
                    kouPosY = -kouHeight;
                }

                //Following four if()s check if Hostage has exited screen, and loops to the other side
                if (otsuPosX > this.Width)
                {
                    otsuPosX = -otsuWidth;
                }

                if (otsuPosX < -otsuWidth)
                {
                    otsuPosX = this.Width;
                }

                if (otsuPosY < -otsuHeight)
                {
                    otsuPosY = this.Height;
                }

                if (otsuPosY > this.Height)
                {
                    otsuPosY = -otsuHeight;
                }
            }

            else if (kouAlive == false && otsuAlive == false)
            {
                //Disable timer if hostage is not alive
                tIsrafel.Enabled = false;
            }
        }

        private void BeamMovement()
        {
            if (beamPUFast == true)
            {
                beamSpeed = beamSpeedDefault * 2;
            }
            else
            {
                beamSpeed = beamSpeedDefault;
            }

            if (beamPUDamage == true)
            {
                beamDamage = beamDamageDefault * 4;
            }
            else
            {
                beamDamage = beamDamageDefault;
            }

            if (beamPUWide == true)
            {
                beamWidth = beamWidthDefault * 4;
            }
            else
            {
                beamWidth = beamWidthDefault;
            }

            //Moves Beam according to direction if alive
            if (beamAlive == true && beamDir == 1)
            {
                beamPosY = beamPosY - beamSpeed;
            }

            if (beamAlive == true && beamDir == 2)
            {
                beamPosX = beamPosX + beamSpeed;
            }

            if (beamAlive == true && beamDir == 3)
            {
                beamPosY = beamPosY + beamSpeed;
            }

            if (beamAlive == true && beamDir == 4)
            {
                beamPosX = beamPosX - beamSpeed;
            }

            //Kills Beam if it exits borders
            if (beamPosX < 0 || beamPosY < 0 || beamPosX + beamLength > this.Width || beamPosY + beamLength > this.Height)
            {
                EntityKill(22);
            }
        }

        //Detects collision between two rectangles
        bool detectCollision(float object1X, float object1Y, float object1Width, float object1Height, float object2X, float object2Y, float object2Width, float object2Height)
        {
            bool collision;
            if ((object1X + object1Width <= object2X || object2X + object2Width <= object1X) || (object1Y + object1Height <= object2Y || object2Y + object2Height <= object1Y))
            {
                collision = false;
            }
            else
            {
                collision = true;
            }
            return collision;
        }

        //Uses detectCollision to check for collisions between objects
        public void CheckCollisions()
        {

            //Check collision between Beam and Zerogouki
            //If true, kill beam and damage enemy
            if (beamAlive == true && zerogoukiAlive == true)
            {
                //vertical collision
                if (beamDir == 1 || beamDir == 3)
                {
                    bool collisionDetectedBeamzerogouki = detectCollision(beamPosX, beamPosY, beamWidth, beamLength, zerogoukiPosX, zerogoukiPosY, zerogoukiWidth, zerogoukiHeight);
                    if (collisionDetectedBeamzerogouki == true)
                    {
                        beamAlive = false;
                        TakeHealth(0, beamDamage);
                        EntityKill(22);
                    }
                }

                //horizontal collision
                if (beamDir == 2 || beamDir == 4)
                {
                    bool collisionBeamzerogouki = detectCollision(beamPosX, beamPosY, beamLength, beamWidth, zerogoukiPosX, zerogoukiPosY, zerogoukiWidth, zerogoukiHeight);
                    if (collisionBeamzerogouki == true)
                    {
                        beamAlive = false;
                        TakeHealth(0, beamDamage);
                        EntityKill(22);
                    }
                }
            }

            //Check collision between Beam and Shogouki
            //If true, damage enemy and kill beam
            if (beamAlive == true && shogoukiAlive == true)
            {
                //vertical collision
                if (beamDir == 1 || beamDir == 3)
                {
                    bool collisionDetectedBeamShogouki = detectCollision(beamPosX, beamPosY, beamWidth, beamLength, shogoukiPosX, shogoukiPosY, shogoukiWidth, shogoukiHeight);
                    if (collisionDetectedBeamShogouki == true)
                    {
                        beamAlive = false;
                        TakeHealth(1, beamDamage);
                        EntityKill(22);
                    }
                }

                //horizontal collision
                if (beamDir == 2 || beamDir ==  4)
                {
                    bool collisionBeamShogouki = detectCollision(beamPosX, beamPosY, beamLength, beamWidth, shogoukiPosX, shogoukiPosY, shogoukiWidth, shogoukiHeight);
                    if (collisionBeamShogouki == true)
                    {
                        beamAlive = false;
                        TakeHealth(1, beamDamage);
                        EntityKill(22);
                    }
                }
            }

            //Check collision between Beam and Sachiel
            //If true, kill beam and damage hostage
            if (beamAlive == true && sachielAlive == true)
            {
                //vertical collision
                if (beamDir == 1 || beamDir == 3)
                {
                    bool collisionDetectedBeamsachiel = detectCollision(beamPosX, beamPosY, beamWidth, beamLength, sachielPosX, sachielPosY, sachielWidth, sachielHeight);
                    if (collisionDetectedBeamsachiel == true)
                    {
                        beamAlive = false;
                        TakeHealth(10, beamDamage);
                        EntityKill(22);
                    }
                }

                //horizontal collision
                if (beamDir == 2 || beamDir == 4)
                {
                    bool collisionBeamsachiel = detectCollision(beamPosX, beamPosY, beamLength, beamWidth, sachielPosX, sachielPosY, sachielWidth, sachielHeight);
                    if (collisionBeamsachiel == true)
                    {
                        beamAlive = false;
                        TakeHealth(10, beamDamage);
                        EntityKill(22);
                    }
                }
            }

            //Check collision between Beam and Kou
            //If true, kill beam and damage enemy
            if (beamAlive == true && kouAlive == true)
            {
                //vertical collision
                if (beamDir == 1 || beamDir == 3)
                {
                    bool collisionDetectedBeamkou = detectCollision(beamPosX, beamPosY, beamWidth, beamLength, kouPosX, kouPosY, kouWidth, kouHeight);
                    if (collisionDetectedBeamkou == true)
                    {
                        beamAlive = false;
                        TakeHealth(11, beamDamage);
                        EntityKill(22);
                    }
                }

                //horizontal collision
                if (beamDir == 2 || beamDir == 4)
                {
                    bool collisionBeamkou = detectCollision(beamPosX, beamPosY, beamLength, beamWidth, kouPosX, kouPosY, kouWidth, kouHeight);
                    if (collisionBeamkou == true)
                    {
                        beamAlive = false;
                        TakeHealth(11, beamDamage);
                        EntityKill(22);
                    }
                }
            }

            //Check collision between Beam and Otsu
            //If true, kill beam and damage enemy
            if (beamAlive == true && otsuAlive == true)
            {
                //vertical collision
                if (beamDir == 1 || beamDir == 3)
                {
                    bool collisionDetectedBeamotsu = detectCollision(beamPosX, beamPosY, beamWidth, beamLength, otsuPosX, otsuPosY, otsuWidth, otsuHeight);
                    if (collisionDetectedBeamotsu == true)
                    {
                        beamAlive = false;
                        TakeHealth(12, beamDamage);
                        EntityKill(22);
                    }
                }

                //horizontal collision
                if (beamDir == 2 || beamDir == 4)
                {
                    bool collisionBeamotsu = detectCollision(beamPosX, beamPosY, beamLength, beamWidth, otsuPosX, otsuPosY, otsuWidth, otsuHeight);
                    if (collisionBeamotsu == true)
                    {
                        beamAlive = false;
                        TakeHealth(12, beamDamage);
                        EntityKill(22);
                    }
                }
            }

            //Check collision between Beam and Player
            //If true, damage enemy and kill beam
            if (beamAlive == true && playerAlive == true)
            {
                //vertical collision
                if (beamDir == 1 || beamDir == 3)
                {
                    bool collisionDetectedBeamplayer = detectCollision(beamPosX, beamPosY, beamWidth, beamLength, playerPosX, playerPosY, playerWidth, playerHeight);
                    if (collisionDetectedBeamplayer == true)
                    {
                        TakeHealth(21, beamDamage);
                        EntityKill(22);
                    }
                }

                //horizontal collision
                if (beamDir == 2 || beamDir == 4)
                {
                    bool collisionBeamplayer = detectCollision(beamPosX, beamPosY, beamLength, beamWidth, playerPosX, playerPosY, playerWidth, playerHeight);
                    if (collisionBeamplayer == true)
                    {
                        TakeHealth(21, beamDamage);
                        EntityKill(22);
                    }
                }
            }

            //Check Collision between Player and Sachiel
            //If true, collect hostage.
            if (sachielAlive == true && playerAlive == true)
            {
                bool collisionPlayerSachiel = detectCollision(playerPosX, playerPosY, playerWidth, playerHeight, sachielPosX, sachielPosY, sachielWidth, sachielHeight);
                if (collisionPlayerSachiel == true)
                {
                    EntityCollect(10);
                    EntityCollect(r.Next(31, 37));
                }
            }

            //Check Collision between Player and Kou
            //If true, collect hostage.
            if (kouAlive == true && playerAlive == true)
            {
                bool collisionPlayerKou = detectCollision(playerPosX, playerPosY, playerWidth, playerHeight, kouPosX, kouPosY, kouWidth, kouHeight);
                if (collisionPlayerKou == true)
                {
                    EntityCollect(11);
                    EntityCollect(r.Next(31, 37));
                }
            }


            //Check Collision between Player and Otsu
            //If true, collect hostage.
            if (otsuAlive == true && playerAlive == true)
            {
                bool collisionPlayerOtsu = detectCollision(playerPosX, playerPosY, playerWidth, playerHeight, otsuPosX, otsuPosY, otsuWidth, otsuHeight);
                if (collisionPlayerOtsu == true)
                {
                    EntityCollect(12);
                    EntityCollect(r.Next(31, 37));
                }
            }


            //Check Collision between Player and Shogouki
            //If true, damage player
            if (shogoukiAlive == true && playerAlive == true)
            {
                bool collisionPlayerShogouki = detectCollision(playerPosX, playerPosY, playerWidth, playerHeight, shogoukiPosX, shogoukiPosY, shogoukiWidth, shogoukiHeight);
                if (collisionPlayerShogouki == true)
                {
                    TakeHealth(21, shogoukiDamage);
                    shogoukiCanMove = false;
                    tShogouki.Enabled = true;
                }
            }

            //Check Collision between Player and Zerogouki
            //If true, damage player
            if (zerogoukiAlive == true && playerAlive == true)
            {
                bool collisionPlayerzerogouki = detectCollision(playerPosX, playerPosY, playerWidth, playerHeight, zerogoukiPosX, zerogoukiPosY, zerogoukiWidth, zerogoukiHeight);
                if (collisionPlayerzerogouki == true)
                {
                    TakeHealth(21, zerogoukiDamage);
                    zerogoukiCanMove = false;
                    tZerogouki.Enabled = true;
                }
            }

            //Check Collision between Shogouki and Sachiel
            //If true, damage Sachiel
            if (sachielAlive == true && shogoukiAlive == true)
            {
                bool collisionshogoukisachiel = detectCollision(shogoukiPosX, shogoukiPosY, shogoukiWidth, shogoukiHeight, sachielPosX, sachielPosY, sachielWidth, sachielHeight);
                if (collisionshogoukisachiel == true)
                {
                    TakeHealth(10, shogoukiDamage);
                }
            }

            //Check Collision between Shogouki and Kou
            //If true, damage Kou
            if (kouAlive == true && shogoukiAlive == true)
            {
                bool collisionshogoukikou = detectCollision(shogoukiPosX, shogoukiPosY, shogoukiWidth, shogoukiHeight, kouPosX, kouPosY, kouWidth, kouHeight);
                if (collisionshogoukikou == true)
                {
                    TakeHealth(11, shogoukiDamage);
                }
            }

            //Check Collision between Shogouki and Otsu
            //If true, damage Otsu
            if (otsuAlive == true && shogoukiAlive == true)
            {
                bool collisionshogoukiotsu = detectCollision(shogoukiPosX, shogoukiPosY, shogoukiWidth, shogoukiHeight, otsuPosX, otsuPosY, otsuWidth, otsuHeight);
                if (collisionshogoukiotsu == true)
                {
                    TakeHealth(12, shogoukiDamage);
                }
            }

            //Check Collision between Zerogouki and Sachiel
            //If true, damage Sachiel
            if (sachielAlive == true && zerogoukiAlive == true)
            {
                bool collisionzerogoukisachiel = detectCollision(zerogoukiPosX, zerogoukiPosY, zerogoukiWidth, zerogoukiHeight, sachielPosX, sachielPosY, sachielWidth, sachielHeight);
                if (collisionzerogoukisachiel == true)
                {
                    TakeHealth(10, zerogoukiDamage);
                }
            }

            //Check Collision between Zerogouki and Kou
            //If true, damage Kou
            if (kouAlive == true && zerogoukiAlive == true)
            {
                bool collisionzerogoukikou = detectCollision(zerogoukiPosX, zerogoukiPosY, zerogoukiWidth, zerogoukiHeight, kouPosX, kouPosY, kouWidth, kouHeight);
                if (collisionzerogoukikou == true)
                {
                    TakeHealth(11, zerogoukiDamage);
                }
            }

            //Check Collision between Zerogouki and Otsu
            //If true, damage Otsu
            if (otsuAlive == true && zerogoukiAlive == true)
            {
                bool collisionzerogoukiotsu = detectCollision(zerogoukiPosX, zerogoukiPosY, zerogoukiWidth, zerogoukiHeight, otsuPosX, otsuPosY, otsuWidth, otsuHeight);
                if (collisionzerogoukiotsu == true)
                {
                    TakeHealth(12, zerogoukiDamage);
                }
            }
        }

        //Updates the state of the Game World
        public void UpdateWorld()
        {
            if (gameOver == false)
            {
                lblHelp.Visible = false;
                PlayerMovement();
                EnemyMovement();
                HostageMovement();
                BeamMovement();
                CheckCollisions();
                CheckHealth();
                this.Text = "Ramiel-chan VS. The Nasty Evas V0.8 - Score: "+playerScore;
                if (debug == true)
                {
                    lblScore.Text = "Score: ∞";
                }
                else
                lblScore.Text = "Score: " + playerScore;
                if (playerScore >= hiscore)
                {
                    lblHiscore.Text = "High: " + hiscore;
                    hiscore = playerScore;
                }
            }
            if (gameOver == true)
            {
                lblHelp.Visible = true;
            }
        }

        //Starts the game, resets all appropriate variables
        private void GameStart()
        {
            gameOver = false;
            playerHealth = playerHealthTotal;
            playerWidth = playerWidthDefault;
            playerHeight = playerHeightDefault;
            playerPosX = (this.Width / 2) - (playerWidth / 2);
            playerPosY = this.Height - (playerHeight * 2);
            playerMoveX = 0;
            playerMoveY = 0;
            playerSpeed = playerSpeedDefault;
            playerDir = 1;
            playerMoveDir = 1;
            playerHealth = playerHealthTotal;
            playerLives = 3;
            playerBombs = 0;
            playerCanMove = true;
            playerCanShoot = true;
            playerCanHurt = true;
            playerCanScore = true;
            playerPUInvuln = false;
            playerPUSpeed = false;
            playerPUShrink = false;
            playerAlive = true;
            playerScore = 0;

            beamPUWide = false;
            beamPUFast = false;
            beamPUDamage = false;

            EntitySpawn(0);
            EntitySpawn(1);
            EntitySpawn(10);
            EntitySpawn(11);
            EntitySpawn(12);


            
        }

        //Takes passed damage from passed Entity's health
        private void TakeHealth(int entityNum, int damage)
        {
            switch (entityNum)
            {
                case 0:
                    zerogoukiHealth -= damage;
                    break;
                case 1:
                    shogoukiHealth -= damage;
                    if (shogoukiSpeed < 3)
                    {
                        shogoukiSpeed++;
                    }
                    break;
                case 10:
                    sachielHealth -= damage;
                    break;
                case 11:
                    kouHealth -= damage;
                    break;
                case 12:
                    otsuHealth -= damage;
                    break;
                case 21:
                    if (playerCanHurt == true && playerPUInvuln == false)
                    {
                        playerHealth -= damage;
                        playerCanHurt = false;
                        tHurt.Enabled = true;
                    }
                    break;
            }
        }

        //Checks health of all entities and kills the appropriate ones
        private void CheckHealth()
        {
            if (zerogoukiHealth <= 0 && zerogoukiAlive == true)
            {
                EntityKill(0);
            }

            if (shogoukiHealth <= 0 && shogoukiAlive == true)
            {
                EntityKill(1);
            }

            if (sachielHealth <= 0 && sachielAlive == true)
            {
                EntityKill(10);
            }

            if (kouHealth <= 0 && kouAlive == true)
            {
                EntityKill(11);
            }

            if (otsuHealth <= 0 && otsuAlive ==true)
            {
                EntityKill(12);
            }

            if (playerHealth <= 0 && playerAlive == true)
            {
                EntityKill(21);
            }
        }

        //Kills the passed Entity
        private void EntityKill(int entityNum)
        {
            switch (entityNum)
            {
                case 0:
                    zerogoukiAlive = false;
                    Score(50);
                    EntitySpawn(0);
                    break;
                case 1:
                    shogoukiAlive = false;
                    Score(50);
                    EntitySpawn(1);
                    break;
                case 10:
                    sachielAlive = false;
                    Score(-50);
                    EntitySpawn(10);
                    break;
                case 11:
                    kouAlive = false;
                    Score(-25);
                    EntitySpawn(11);
                    break;
                case 12:
                    otsuAlive = false;
                    Score(-25);
                    EntitySpawn(12);
                    break;
                case 21:
                    playerLives--;
                    if (playerLives >= 0)
                    {
                        playerHealth = playerHealthTotal;
                        playerPUInvuln = false;
                        playerPUSpeed = false;
                        playerPUShrink = false;
                        beamPUWide = false;
                        beamPUFast = false;
                        beamPUDamage = false;
                        playerCanMove = true;
                    }
                    else
                    {
                        gameOver = true;
                    }
                    break;
                case 22:
                    beamAlive = false;
                    playerCanShoot = true;
                    break;
            }
        }

        //Spawns the passed Entity into the game world
        private void EntitySpawn(int entityNum)
        {
            switch (entityNum)
            {
                case 0:
                    zerogoukiAlive = true;
                    zerogoukiCanMove = true;
                    zerogoukiHealth = zerogoukiHealthTotal;
                    zerogoukiPosY = r.Next(0, (int)(this.Height - zerogoukiHeight));
                    zerogoukiPosX = r.Next(0, (int)(this.Width - zerogoukiWidth));
                    break;
                case 1:
                    shogoukiAlive = true;
                    shogoukiCanMove = true;
                    shogoukiHealth = shogoukiHealthTotal;
                    shogoukiSpeed = 1;
                    shogoukiPosY = r.Next(0, (int)(this.Height - shogoukiHeight));
                    shogoukiPosX = r.Next(0, (int)(this.Width - shogoukiWidth));
                    break;
                case 10:
                    sachielAlive = true;
                    sachielHealth = sachielHealthTotal;
                    sachielPosY = r.Next(0, (int)(this.Height - sachielHeight));
                    sachielPosX = r.Next(0, (int)(this.Width - sachielWidth));
                    break;
                case 11:
                    kouAlive = true;
                    kouHealth = kouHealthTotal;
                    if (otsuAlive == true)
                    {
                        kouPosY = otsuPosX;
                        kouPosX = otsuPosY - otsuHeight * 2;
                    }
                    if (otsuAlive == false)
                    {
                        otsuPosY = r.Next(0, (int)(this.Height - otsuHeight));
                        otsuPosX = r.Next(0, (int)(this.Width - otsuWidth));
                    }
                    break;
                case 12:
                    otsuAlive = true;
                    otsuHealth = otsuHealthTotal;
                    if (kouAlive == true)
                    {
                        otsuPosY = kouPosX;
                        otsuPosX = kouPosY + kouHeight * 2;
                    }
                    if (kouAlive == false)
                    {
                        otsuPosY = r.Next(0, (int)(this.Height - otsuHeight));
                        otsuPosX = r.Next(0, (int)(this.Width - otsuWidth));
                    }

                    break;
                case 21:
                    playerWidth = playerWidthDefault;
                    playerHeight = playerHeightDefault;
                    playerPosX = (this.Width / 2) - (playerWidth / 2);
                    playerPosY = this.Height - (playerHeight * 2);
                    playerMoveX = 0;
                    playerMoveY = 0;
                    playerSpeed = playerSpeedDefault;
                    playerDir = 1;
                    playerMoveDir = 1;
                    playerHealthTotal = 3;
                    playerHealth = playerHealthTotal;
                    playerLives = 3;
                    playerBombs = 0;
                    playerCanMove = true;
                    playerCanShoot = true;
                    playerCanHurt = true;
                    playerCanScore = true;
                    playerPUInvuln = false;
                    playerPUSpeed = false;
                    playerPUShrink = false;
                    playerAlive = true;
                    break;
            }
        }

        //Collects the passed Entity, adds score
        private void EntityCollect(int entityNum)
        {
            switch (entityNum)
            {
                case 10:
                    Score(50);
                    sachielAlive = false;
                    EntitySpawn(10);
                    break;
                case 11:
                    Score(25);
                    kouAlive = false;
                    EntitySpawn(11);
                    break;
                case 12:
                    Score(25);
                    otsuAlive = false;
                    EntitySpawn(12);
                    break;
                case 31:
                    beamPUWide = true;
                    tWide.Enabled = true;
                    break;
                case 32:
                    beamPUFast = true;
                    tFast.Enabled = true;
                    break;
                case 33:
                    beamPUDamage = true;
                    tDamage.Enabled = true;
                    break;
                case 34:
                    playerPUInvuln = true;
                    tInvuln.Enabled = true;
                    break;
                case 35:
                    playerPUSpeed = true;
                    tSpeed.Enabled = true;
                    break;
                case 36:
                    playerPUShrink = true;
                    tShrink.Enabled = true;
                    break;
            }
        }

        //Adds the passed ammount of score to player's score
        private void Score(int addedScore)
        {
            if (playerCanScore == true)
            {
                playerScore += addedScore;
            }
        }

        //Detects Key Down events
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.W)
                {
                    playerMoveDir = 1;
                    playerMoveY = -playerSpeed;
                }

                if (e.KeyCode == Keys.A)
                {
                    playerMoveDir = 2;
                    playerMoveX = -playerSpeed;
                }

                if (e.KeyCode == Keys.S)
                {

                    playerMoveDir = 3;
                    playerMoveY = playerSpeed;
                }

                if (e.KeyCode == Keys.D)
                {

                    playerMoveDir = 4;
                    playerMoveX = playerSpeed;
                }

                //when we press fire, we want the bullet to appear from the middle of our angel
                //so we offset the x and y positions based on the sides of the angel and the sides
                //of the bullet. We assign a direction for the bullet to travel in based on key input.
                //Finally, the bulletAlive variable is set to true

                if (e.KeyCode == Keys.Up && playerCanShoot == true)
                {
                    beamPosX = playerPosX + (playerWidth / 2 - beamWidth / 2);
                    beamPosY = playerPosY - beamLength;
                    playerDir = 1;
                    beamDir = 1;
                    beamAlive = true;
                    playerCanShoot = false;
                }

                if (e.KeyCode == Keys.Right && playerCanShoot == true)
                {
                    beamPosX = playerPosX + playerWidth;
                    beamPosY = playerPosY + (playerHeight / 2 - beamWidth / 2);
                    playerDir = 2;
                    beamDir = 2;
                    beamAlive = true;
                    playerCanShoot = false;
                }

                if (e.KeyCode == Keys.Down && playerCanShoot == true)
                {
                    beamPosX = playerPosX + (playerWidth / 2 - beamWidth / 2);
                    beamPosY = playerPosY + playerHeight;
                    playerDir = 3;
                    beamDir = 3;
                    beamAlive = true;
                    playerCanShoot = false;
                }

                if (e.KeyCode == Keys.Left && playerCanShoot == true)
                {
                    beamPosX = playerPosX - beamLength;
                    beamPosY = playerPosY + (playerHeight / 2 - beamWidth / 2);
                    playerDir = 4;
                    beamDir = 4;
                    beamAlive = true;
                    playerCanShoot = false;
                }
                
                //Closes Game
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }

                if (e.KeyCode == Keys.F5 && (debug == true || gameOver == true))
                {
                    GameStart();
                }

                //Debug: Disables scoring, enables enemy spawning and parameter editing.

                if (e.KeyCode == Keys.Return)
                {
                    debug = true;
                    //playerCanScore = false;
                }

                if (e.KeyCode == Keys.D0 && debug == true)
                {
                    EntitySpawn(0);
                }

                if (e.KeyCode == Keys.D1 && debug == true)
                {
                    EntitySpawn(1);
                }

                if (e.KeyCode == Keys.NumPad0 && debug == true)
                {
                    EntitySpawn(10);
                }

                if (e.KeyCode == Keys.NumPad1 && debug == true)
                {
                    EntitySpawn(11);
                }

                if (e.KeyCode == Keys.NumPad2 && debug == true)
                {
                    EntitySpawn(12);
                }

                //Keys for incrementing and decrementing Player variables
                if (e.KeyCode == Keys.NumPad7 && debug == true)
                {
                    playerHealth = 0;
                }

                if (e.KeyCode == Keys.NumPad8 && debug == true)
                {
                    if (playerHealth > 0)
                    {
                        playerHealth -= 1;
                    }
                }

                if (e.KeyCode == Keys.NumPad9 && debug == true)
                {
                    if (playerHealth < playerHealthTotal)
                    {
                        playerHealth += 1;
                    }
                }

                if (e.KeyCode == Keys.Multiply && debug == true && playerLives < 3)
                {
                    playerLives++;
                }

                if (e.KeyCode == Keys.Divide && debug == true && playerLives > 0)
                {
                    playerLives--;
                }

                if (e.KeyCode == Keys.Add && debug == true && playerBombs < 3)
                {
                    playerBombs++;
                }

                if (e.KeyCode == Keys.Subtract && debug == true && playerBombs > 0)
                {
                    playerBombs--;
                }


                //Keys for enabling or disabling powerups
                if (e.KeyCode == Keys.Insert && debug == true)
                {
                    if (beamPUWide == false)
                    {
                        beamPUWide = true;
                    }
                    else if (beamPUWide == true)
                    {
                        beamPUWide = false;
                    }
                }

                if (e.KeyCode == Keys.Home && debug == true)
                {
                    if (beamPUFast == false)
                    {
                        beamPUFast = true;
                    }
                    else if (beamPUFast == true)
                    {
                        beamPUFast = false;
                    }
                }

                if (e.KeyCode == Keys.PageUp && debug == true)
                {
                    if (beamPUDamage == false)
                    {
                        beamPUDamage = true;
                    }
                    else if (beamPUDamage == true)
                    {
                        beamPUDamage = false;
                    }
                }

                if (e.KeyCode == Keys.Delete && debug == true)
                {
                    if (playerPUInvuln == false)
                    {
                        playerPUInvuln = true;
                    }
                    else if (playerPUInvuln == true)
                    {
                        playerPUInvuln = false;
                    }
                }

                if (e.KeyCode == Keys.End && debug == true)
                {
                    if (playerPUSpeed == false)
                    {
                        playerPUSpeed = true;
                    }
                    else if (playerPUSpeed == true)
                    {
                        playerPUSpeed = false;
                    }
                }

                if (e.KeyCode == Keys.PageDown && debug == true)
                {
                    if (playerPUShrink == false)
                    {
                        playerPUShrink = true;
                    }
                    else if (playerPUShrink == true)
                    {
                        playerPUShrink = false;
                    }
                }
        }

        //Detects Key Up Events
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //To stop moving when a key is released
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.S)
            {
                playerMoveY = 0;
            }

            if (e.KeyCode == Keys.A || e.KeyCode == Keys.D)
            {
                playerMoveX = 0;
            }

        }

        //Detects Mouse Down Events
        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //allows moving the window by clicking anywhere
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //Randomises direction of hostage every four seconds
        private void tSachiel_Tick(object sender, EventArgs e)
        {
            sachielDir = (int)r.Next(1, 5);
        }
        //Randomises direction of hostage every two seconds
        private void tIsrafel_Tick(object sender, EventArgs e)
        {
            israfelDir = (int)r.Next(1, 5);
        }
        //Temporary invulnerability when hit
        private void tHurt_Tick(object sender, EventArgs e)
        {
            playerCanHurt = true;
        }
        
        //Enemy stops moving on damaging player
        private void tZerogouki_Tick(object sender, EventArgs e)
        {
            zerogoukiCanMove = true;
        }

        //Enemy stops moving on damaging player
        private void tShogouki_Tick(object sender, EventArgs e)
        {
            shogoukiCanMove = true;
        }

        //Randomises direction of enemy every four seconds
        private void tZerogoukiMove_Tick(object sender, EventArgs e)
        {
            zerogoukiDir = (int)r.Next(1, 5);
        }

        //Disables powerup and timer
        private void tWide_Tick(object sender, EventArgs e)
        {
            beamPUWide = false;
            tWide.Enabled = false;
        }

        //Disables powerup and timer
        private void tFast_Tick(object sender, EventArgs e)
        {
            beamPUFast = false;
            tFast.Enabled = false;
        }

        //Disables powerup and timer
        private void tDamage_Tick(object sender, EventArgs e)
        {
            beamPUDamage = false;
            tDamage.Enabled = false;
        }

        //Disables powerup and timer
        private void tInvuln_Tick(object sender, EventArgs e)
        {
            playerPUInvuln = false;
            tInvuln.Enabled = false;
        }

        //Disables powerup and timer
        private void tSpeed_Tick(object sender, EventArgs e)
        {
            playerPUSpeed = false;
            tSpeed.Enabled = false;
        }
        //Disables powerup and timer
        private void tShrink_Tick(object sender, EventArgs e)
        {
            playerPUShrink = false;
            tShrink.Enabled = false;
        }

        private void lblHelp_Click(object sender, EventArgs e)
        {

        }

    }
}