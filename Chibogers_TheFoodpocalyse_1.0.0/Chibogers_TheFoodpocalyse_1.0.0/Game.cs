using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace Chibogers_TheFoodpocalyse_1._0._0
{
    internal class Game : Form {
        public static Game here;
        public Button btnFight = new Button();
        public Button btnSummon = new Button();
        public Button btnUseItem = new Button();
        public Button btnSurrender = new Button();
        int floor = 1;//testing the leaderboards functionality
        int turn = 1;

        static string Introd = "It is a peaceful day where everyone was going on by their daily lives. However... A sudden loud noise came crashing into the earth’s atmosphere as the skies have turned red.. A meteor had fell off to the earth that caused a huge shockwave…. And all of the sudden… plants, insects, and animals started mutating and began attacking humans. And on the brink of humanity its up to the MC(Masterchef Chibogs) and the Chiboggers to fight off these “Metamorphs”. To save the world? Or to Survive?";
        static string P1 = "Everything is in chaos. you can hear outside the window of your apartment that people are screaming and are being chased by oddly weird looking creatures that resembles a plant, insect, and animals. and all of the sudden a mutated cow bursts into your door. YOU: Wha… WHY IS THERE A WEIRD COW IN THIS BUILDING?";
        static string P2 = "After managing to outwit the oddly looking cow, you run as fast as you can to get out of the room and locked the door behind you. You heard a grunt beside you. As you turn around you immediately are faced with multiple mutated plants staring at you. YOU: AHHH!!!. As you ran you kept on attracting more metamorphed plants and FISHES?’. YOU: WHY IS THIS HAPPENING TO ME??. And now you have to break through multiple of them to escape the building";
        static string P3 = "After breaking through them, you managed to run into a dark alley where it looks like no weird looking mutants are lurking…. YOU: Breaths Heavily*. YOU: I cant… there is so many! What is happening in this world??? . You stopped and quickly analyze your surroundings hoping to get an answer. Checking your phone and you where shocked by the amount of news about the situation and began checking them one by one. Apparently these mutated creatures are called metamorphs, they are any living organisms that where affected by the shockwave of the meteor and for unknown reason it doesn’t affect us humans. However… man-made weaponry had no effect on these metamorphs and just told everyone to hide and not to engage with them until “cure” is found.. After reading you have come up to your senses and began to calm down and think. YOU: looks like I’ll need to hide for now. All of the sudden, you felt something that touched your shoulder";
        static string P4 = "You screamed as you swiftly strike it away. YOU: AHHHHHHH!!. You felt stupid when you realized that it was just a branch from a wall. YOU: Wait… Why is there a branch in this wall?. Looking closely, it looked like there is a noticable gap in between the branch which you tried to push it. Nothing seems to be happening yet you tried to push it harder, and it suddenly barged all the way that leads to an underground tunnel. YOU: this looks oddly suspicious but this is better than trying to survive in the surface";
        static string P5 = "You went inside the underground tunnel that looked like someone used to live here. There’s an old tv, a sofa with a carpet beside it, a fridge, some books. YOU: Wait a fridge! There is probably some goodies here . You were welcomed by a punget smell. YOU: Ack! What did I expect… this looked like abandoned in years. YOU: On the Bright side, I now have a safe base to go back to.. YOU: Aight lets get to fixing and cleaning up this place to call it my home. Nearby, you saw some cleaning materials like a broom and a brush, and the faucet here is working and began cleaning and tidying things up.. While cleaning, when you lift the carpet you saw a hatch door. YOU: an underground tunnel with another underground tunnel?";
        static string P6 = "You saw a weird looking lock, and realized you ca  n’t force it to open, and began looking for “tools” to open/break it. But to no avail the lock seemed indestructible…. You left it for now, and finished your base cleaning first. YOU: Finally! Finished cleaning, but I still wonder whats inside of that hatch. YOU: But I still need to gather food first. YOU: Well I guess its time to get food first and… head outside again..";
        static string P7 = "Years have passed…. You can no longer see anyone on the streets besides the metamorphs, and the signal and internet is now down. And you are still on the same routine: eat, Fix Base, Gather resources and food when needed, Go back home, eat,  try to open the hatch, workout when done, then sleep. However, everytime you tried to open the hatch it always doesn’t break or seemed like its taking damage. And you can’t break the hatch itself because it is made up of well coated concrete that looked like has hard steel frames, and forcing it to open could make too much noise that could led metamorphs to my base. Feeling tired, you are now curious and finally tried to check the books if there’s something interesting in them. However, the words seems like its not in english nor you have seen before, as you check the other pages…. You where shocked yet ecstatic as you see a weird looking key that is placed on tha pages that has been etched that became the holder for the key. YOU: This might be it!";
        static string P8 = "*Click*. The lock opens and you began openning it with all your might because of how heavy the hatch is, and as you openned it…. YOU: wait that’s it?. In front of you is just some plain old glasses. But suddenly you realized that maybe it had something to do with those books. You wore it, and it is just like a lensless glasses, but when you tried reading the pages of the book. Suddenly you can understand them like its in english!. You began wearing and taking it off checking if your mind is just playing tricks on you, but it doesn’t.. You are shocked because the contents of it is like someone already studied these metamorphs before and it is so well documented that it is frightening, because it looked like someone already had encountered with them. According to the book, the Chibog Chef wrote this book and is the only that lead the chiboggers to fight off these metamorphs.. You read further in the pages and it explains the weaknesses of each metamorph and there is a noticable pattern depending on which they came from, for examble in green plants it is always on the bottom of their body, and for range plants its on the top side of their body. It would have been easy if its not the most protected place of each one…. There are recipes on which these ingredients came from them and some can weaken them, poison them, and most important of all, inflict damage on them and further increase the damage you inflicted them with.. Something piqued your interest… . YOU: It is said here that we can actually make food out of them and they are safe to eat.. atleast according to the book…. You are also getting desperate because food is now scarce, and you have no choice but to risk it or just wait till eventually you can no longer find food and die.. You sat there studying the books for a long time and practice aiming on the “patterns”. A month has passed and now you don’t have anymore food to eat, and had no choice but to fight and gather resources from them instead.. YOU: I guess… it’s now or never!";
        static string P9 = "Months has passed since you have last read the book, and now you have mastered every pattern, every craftables and every recipes by instinct.. YOU: And honestly at first, looking at them and eating them looks like it could kill you from poisining. YOU: However, after killing them and trying to cook them, it surprisingly turned them back into their original form and it is oddly quite fresh. YOU: After eating them, the tasted delicious and the best part is it doesn’t affect my stomach in any way!. YOU: If only I could tell this to anyone but sadly the signal has been dead for a long time. And now you only have one more choice, and it is to find for survivors and teach them how to survive in this apocalypse and to fight off these metamorphs. Slowly but surely you were finding survivors and now they follow you, The great Chibog Chef! And them the Chiboggers who will always be loyal to you and go wherever you go.";
        static string P10 = "Years have passed, and now your numbers have grown a lot, and now you are deciding. YOU: My Chiboggers, I think… no, I am sure we can win amidst these chaos and finally no longer hide from these metamorphs.. YOU: I say we destroy their source… and it is that very meteor that fell off this Earth when the metamorphs started to mutate, they say it is indestructible but I know the patterns but oh boy theres a lot of it.... YOU: I know it is too much for me to ask because I know everyone just wants to live and survive. YOU: But I won’t let these metamorphs takes what is ours! And as the Chibog Chef it is my duty to protect every chiboggers, and defeat these metamorphs. YOU: It is your choice, to stay here or to join me in my journey and I promise you, if you join me I will guarantee you that we will no longer take back what is ours, and its FREEDOM!. YOU: So, who wants to join me?. Someone: You save us when we needed help, and now it is time to payback and help you in this journey!. One agreed until eventually everyone agreed and now everyone is shouting to join!. YOU: That’s what I’d like to hear!. YOU: Prepare you tools, your weapons, your everything because we will embark in this long journey for the quest of freedom"; 
        static string[] story = { Introd, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10 };

        public HP playerHP;
        public int playerDef = 30;
        public float playerMultiplier = 1;
        int luck = 0;
        HP enemyHP;
        int enemyDef = 30;
        float enemyMultiplier = 1;
        Random random = new Random();
        Dictionary<string, float> weathers = new Dictionary<string, float>() {
            {"Clear skies", 1},
            {"Rainy", 1.5f},
            {"Blizzard", .5f},
            {"Heatwave", .75f}
        };
        string currentWeather = "Clear skies";

        public Game() {
            here = this;

            playerHP = new HP(1000, 300, 40, true);
            playerHP.bar.Move((Size.Width / 2) - 40, 155);
            enemyHP = new HP(1000, 300, 60);
            enemyHP.bar.Move((Size.Width / 2) - 40, 0);
            Text = $"Floor {floor}";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ControlBox = false;

            Controls.Add(btnFight);
            btnFight.Text = "Fight";
            btnFight.Dock = DockStyle.Bottom;
            btnFight.FlatStyle = FlatStyle.Popup;
            btnFight.MouseLeave += (s, e) => btnFight.BackColor = Color.WhiteSmoke;
            btnFight.MouseHover += (s, e) => btnFight.BackColor = Color.YellowGreen;
            btnFight.Click += new EventHandler(btnFight_click);

            Controls.Add(btnSummon);
            btnSummon.Text = "Summon";
            btnSummon.Dock = DockStyle.Bottom;
            btnSummon.FlatStyle = FlatStyle.Popup;
            btnSummon.MouseLeave += (s, e) => btnSummon.BackColor = Color.WhiteSmoke;
            btnSummon.MouseHover += (s, e) => btnSummon.BackColor = Color.YellowGreen;
            btnSummon.Click += new EventHandler(btnSummon_click);

            Controls.Add(btnUseItem);
            btnUseItem.Text = "Use Item";
            btnUseItem.Dock = DockStyle.Bottom;
            btnUseItem.FlatStyle = FlatStyle.Popup;
            btnUseItem.MouseLeave += (s, e) => btnUseItem.BackColor = Color.WhiteSmoke;
            btnUseItem.MouseHover += (s, e) => btnUseItem.BackColor = Color.YellowGreen;
            btnUseItem.Click += new EventHandler(btnUseItem_click);

            Controls.Add(btnSurrender);
            btnSurrender.Text = "Surrender";
            btnSurrender.Dock = DockStyle.Bottom;
            btnSurrender.FlatStyle = FlatStyle.Popup;
            btnSurrender.MouseLeave += (s, e) => btnSurrender.BackColor = Color.WhiteSmoke;
            btnSurrender.MouseHover += (s, e) => btnSurrender.BackColor = Color.YellowGreen;
            btnSurrender.Click += new EventHandler(btnSurrender_click);
            MessageBox.Show(story[0]);
            newTurn();
        }

        void newTurn()
        {
            Text = $"Floor {floor} : Turn {turn} : {currentWeather}";
            turn++;
            //reset properties
            playerDef = 30;
            playerMultiplier = 1;
            luck = 0;
            enemyDef = 30;
            enemyMultiplier = (floor + 4) / 5;
            //refresh chiboger cooldowns
            foreach (Chiboger chiboger in Chiboger.list) chiboger.Renew();
            //weather calculation, every turn, there's a 10% for the weather to change
            if (random.Next(1, 10) == 1) currentWeather = weathers.Keys.ToArray()[random.Next(0, 3)];
            Console.WriteLine(currentWeather);
            float weatherMultiplier = weathers[currentWeather];
            //coutdown effects
            for (int i = 0; i < Effect.list.Count; i++) if (!Effect.list[i].InEffect()) i--;

            PictureBox enemySkin = new PictureBox();
            enemySkin.Image = Properties.Resources.BrogolliGroup;
            enemySkin.SizeMode = PictureBoxSizeMode.StretchImage;
            enemySkin.Size = new Size(70, 70);
            enemySkin.Location = new Point(Size.Width / 3, 25);
            here.Controls.Add(enemySkin);

            
            

            switch (random.Next(1, 2))
            {
                case 1: //small dmg
                    luck = random.Next(1, 10);
                    if (luck == 1 && ((int)(50 * enemyMultiplier * weatherMultiplier * ((9 + floor) / 10)) - enemyDef) > 0) { enemyHP.Damage((int)(50 * playerMultiplier * 2 * ((9 + floor) / 10)) - enemyDef); Console.WriteLine((int)(50 * playerMultiplier * 2 * ((9 + floor) / 10)) - playerDef); }
                    else if (luck != 1 && ((int)(20 * enemyMultiplier * weatherMultiplier * ((9 + floor) / 10)) - enemyDef) > 0) { enemyHP.Damage((int)(50 * playerMultiplier * 1 * ((9 + floor) / 10)) - playerDef); Console.WriteLine((int)(50 * playerMultiplier * 2 * ((9 + floor) / 10)) - playerDef); }
                    break;
                case 2: //big dmg
                    luck = random.Next(1, 10);
                    if (luck == 1 && ((int)(20 * enemyMultiplier * weatherMultiplier * ((9 + floor) / 10)) - enemyDef) > 0) { enemyHP.Damage((int)(50 * playerMultiplier * 2 * ((9 + floor) / 10)) - enemyDef); Console.WriteLine((int)(50 * playerMultiplier * 2 * ((9 + floor) / 10)) - playerDef); }
                    else if (luck != 1 && ((int)(20 * enemyMultiplier * weatherMultiplier * ((9 + floor) / 10)) - enemyDef) > 0) { enemyHP.Damage((int)(50 * playerMultiplier * 1 * ((9 + floor) / 10)) - playerDef); Console.WriteLine((int)(50 * playerMultiplier * 2 * ((9 + floor) / 10)) - playerDef); }
                    break;
            }

            //check enemy death
            if (enemyHP.current < 1) {
                Console.WriteLine("Ooh, she dead");
                floor++;
                if (floor < 11) MessageBox.Show(story[floor]);
                Text = $"Floor {floor} : Turn {turn} : {currentWeather}";
                Item.LootItems();
                enemyHP.Set(1000 * (floor + 4/ 5));
                enemyHP.bar.Move((Size.Width / 2) - 40, 0);

            }
            int target;
            //enemy attacks
            Console.WriteLine("Enemy is attacking");
            switch (random.Next(1, 3))
            {
                case 1: //single
                    target = random.Next(1, 1 + Chiboger.list.Count);
                    if (target == 1 && ((int)(50 * playerMultiplier * weatherMultiplier * ((9 + floor) / 10)) - playerDef) > 0) playerHP.Damage((int)(50 * enemyMultiplier * weatherMultiplier * ((9 + floor) / 10)) - playerDef);
                    else if (target != 1 && ((int)(50 * playerMultiplier * ((9 + floor) / 10)) - Chiboger.list[target - 2].GetDef()) > 0) Chiboger.list[target - 2].hp.Damage((int)(50 * enemyMultiplier * ((9 + floor) / 10)) - Chiboger.list[target - 2].GetDef());
                    break;
                case 2: //bounce
                    for (int i = 0; i < 3; i++) {
                        target = random.Next(1, 1 + Chiboger.list.Count);
                        if (target == 1 && ((int)(20 * playerMultiplier * weatherMultiplier * ((9 + floor) / 10)) - playerDef) > 0) playerHP.Damage((int)(20 * enemyMultiplier * weatherMultiplier * ((9 + floor) / 10)) - playerDef);
                        else if (target != 1 && ((int)(20 * playerMultiplier * ((9 + floor) / 10)) - Chiboger.list[target - 2].GetDef()) > 0) Chiboger.list[target - 2].hp.Damage((int)(20 * enemyMultiplier * ((9 + floor) / 10)) - Chiboger.list[target - 2].GetDef());
                    }
                    break;
                case 3: //aoe
                    if (((int)(5 * playerMultiplier * weatherMultiplier * ((9 + floor) / 10)) - playerDef) > 0) playerHP.Damage((int)(5 * enemyMultiplier * weatherMultiplier * ((9 + floor) / 10)) - playerDef);
                    foreach (Chiboger chiboger in Chiboger.list) if (((int)(5 * playerMultiplier * ((9 + floor) / 10)) - chiboger.GetDef()) > 0) chiboger.hp.Damage((int)(5 * enemyMultiplier * ((9 + floor) / 10)) - chiboger.GetDef());
                    break;
            }
        }

        void btnFight_click(object sender, EventArgs e) {
            //fight
            //Chiboger chiboger = Chiboger.list[0];
            //chiboger.Kill();
            newTurn();
        }

        void btnSummon_click(object sender, EventArgs e) {
            //summons
            if (Chiboger.list.Count > 3) {
                MessageBox.Show("You can only summon 4 chibogers at once");
                return;
            }
            ChibogerPanels chibogerPanels = new ChibogerPanels();
            here.Enabled = false;
            chibogerPanels.Show();
            Console.WriteLine("Moving chibogers==================================");
        }

        void btnUseItem_click(object sender, EventArgs e) {
            Inventory playerInventory = new Inventory();
            playerInventory.Show();

        }

        void btnSurrender_click(object sender, EventArgs e) 
        {
            SurrenderEvent();
            PlayerLose();
        }

        private void SurrenderEvent()
        {
            playerHP.Set(0);
            playerHP.bar.Edit(0, playerHP.bar.max);
            MessageBox.Show("You have surrendered.");
        }
        #region methods used for the process of saving the scores when the player loses
        private void PlayerLose()
        {
            MessageBox.Show("You Lost.");
            string playerName;
            bool playerNameAccepted = false;
            Chiboger.list.Clear();
            Effect.list.Clear();

            DialogResult result = MessageBox.Show("Do you want to enter your username for a chance to be included in the leaderboards?", "", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                while (!playerNameAccepted)
                {
                    playerName = AskForUsername();
                    if (!string.IsNullOrWhiteSpace(playerName))
                    {
                        SaveScores(playerName, floor);
                        this.Close();
                        playerNameAccepted = true;
                    }
                    else
                    {
                        // If the user entered nothing
                        MessageBox.Show("Username cannot be empty. Please try again.");
                    }
                }
            }
            else if (result == DialogResult.No)
            {
                this.Close();
            }
        }
        private string AskForUsername() {
            TextBox textBox = new TextBox();

            Label label = new Label();
            label.Text = "Enter Username:";
            label.Location = new Point(0, 30);

            Form UsernameEntryForm = new Form();
            UsernameEntryForm.Text = "Username Entry";


            UsernameEntryForm.Controls.Add(label);
            UsernameEntryForm.Controls.Add(textBox);
            label.Location = new Point(0, 30);
            textBox.Location = new Point(100, 30);


            Button btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.DialogResult = DialogResult.OK;
            UsernameEntryForm.Controls.Add(btnOK);
            btnOK.Location = new Point(50, 70);

            DialogResult playerNameresult = UsernameEntryForm.ShowDialog();


            if (playerNameresult == DialogResult.OK) {
                return textBox.Text;
            }
            return ""; // returns blank if user enters nothing
        }
        void SaveScoresToFile(List<ScoreEntry> scores) {
            using (StreamWriter sw = new StreamWriter("Scores.txt")) {
                foreach (var entry in scores) {
                    sw.WriteLine("Player Name: {0}", entry.PlayerName);
                    sw.WriteLine("Highest Floor Reached: {0}", entry.Score);
                }
            }
        }

        void SaveScores(string playerName, int score) {
            List<ScoreEntry> scores = Leaderboards.LoadScores();


            ScoreEntry existingPlayer = scores.Find(entry => entry.PlayerName == playerName && entry.Score == score);

            // check if player with the same username and with the same score already exists
            if (existingPlayer != null) {

                DialogResult enterUsernameAgain = MessageBox.Show("The same username with the exact same score already exists. Do you still want to enter a username?", "", MessageBoxButtons.YesNo);
                //enter another username if yes
                if (enterUsernameAgain == DialogResult.Yes) {
                    playerName = AskForUsername();
                    if (!string.IsNullOrWhiteSpace(playerName)) {
                        SaveScores(playerName, score);
                        this.Close();
                        return;
                    }
                    //walang linagay
                    else {
                        MessageBox.Show("Username cannot be empty. Exiting the game.");
                        this.Close();
                        return;
                    }
                }
                //back to mainmenu if no
                else if (enterUsernameAgain == DialogResult.No) {
                    this.Close();
                    return;
                }
            } else {

                existingPlayer = scores.Find(entry => entry.PlayerName == playerName);

                if (existingPlayer != null)//checks if player already exists pero iba score/floor
                {
                    if (score > existingPlayer.Score) {
                        //override the player's old score with the new one if its higher
                        existingPlayer.Score = score;
                    } else//option to enter a new username
                      {

                        DialogResult enterUsernameAgain = MessageBox.Show("The score associated with this username is not higher than the previous score. Do you still want to enter a username?", "", MessageBoxButtons.YesNo);
                        //enter another username if yes
                        if (enterUsernameAgain == DialogResult.Yes) {
                            playerName = AskForUsername();
                            if (!string.IsNullOrWhiteSpace(playerName)) {
                                SaveScores(playerName, score);
                                this.Close();
                                return;
                            }
                            //walang linagay
                            else {
                                MessageBox.Show("Username cannot be empty. Exiting the game.");
                                this.Close();
                                return;
                            }
                        }
                        //back to mainmenu if no
                        else if (enterUsernameAgain == DialogResult.No) {
                            this.Close();
                            return;
                        }

                    }
                } else//unique entry
                  {
                    scores.Add(new ScoreEntry(playerName, score));
                }
            }
            SaveScoresToFile(scores);
        }
        #endregion

        //backend
        //Chiboger panels
        public class ChibogerPanels : Form {
            public ChibogerPanels() {
                ControlBox = false;
                FormBorderStyle = FormBorderStyle.None;
                int i = 0;
                for (; i < 6; i++) {
                    Button button = new Button();
                    button.Size = new Size(300, 20);
                    button.Location = new Point(0, i * 20);
                    Controls.Add(button);
                    switch (i) {
                        case 0: button.Text = "Gordon Ramsay : enemy ATK and DEF debuff"; button.Click += new EventHandler(Gordon_Click); break;
                        case 1: button.Text = "Guy Fieri : Burn debuff"; button.Click += new EventHandler(Guy_Click); break;
                        case 2: button.Text = "Bobby Flay : Healing"; button.Click += new EventHandler(Bobby_Click); break;
                        case 3: button.Text = "Jamie Oliver : DEF buff"; button.Click += new EventHandler(Jamie_Click); break;
                        case 4: button.Text = "Michael Caines : ATK buff"; button.Click += new EventHandler(Michael_Click); break;
                        case 5: button.Text = "Uncle Roger : LUCK buff"; button.Click += new EventHandler(Uncle_Click); break;
                    }
                }
                Size = new Size(300, i * 20);
            }
            void Gordon_Click(object sender, EventArgs e) { new GordonRamsay();  End(); }
            void Guy_Click(object sender, EventArgs e) { new GuyFieri(); End(); }
            void Bobby_Click(object sender, EventArgs e) { new BobbyFlay(); End(); }
            void Jamie_Click(object sender, EventArgs e) { new JamieOliver(); End(); }
            void Michael_Click(object sender, EventArgs e) { new MichaelCaines(); End(); }
            void Uncle_Click(object sender, EventArgs e) { new UncleRoger(); End(); }
            void End() {
                here.Enabled = true;
                Hide();
                int i = 0;
                foreach (Chiboger chiboger in Chiboger.list) {
                    chiboger.Move(i * (Size.Width / 4), 120);
                    i++;
                }
                here.newTurn();
            }
        }
        //Effects
        public class Effect {
            public static List<Effect> list = new List<Effect>();
            public int cooldown = 0;
            public int duration;
            public delegate void EffectAction();
            EffectAction effect;
            public Effect(EffectAction effect, int duration) {
                this.effect = effect;
                this.duration = duration;
                list.Add(this);
            }
            public bool InEffect() {
                bool effective = --cooldown > 0;
                if (effective) effect();
                else list.Remove(this);
                return effective;
            }
        }
        //Chibogers
        public abstract class Chiboger {
            public abstract string name { get; }
            public PictureBox skin = new PictureBox();
            public HP hp;
            public static List<Chiboger> list = new List<Chiboger>();
            protected Effect chibogerEffect;
            public Chiboger() {
                list.Add(this);
            }
            public void Kill() {
                list.Remove(this);
                skin.Dispose();
                Console.WriteLine($"{name} has died!");
                int i = 0;
                foreach (Chiboger chiboger in list) {
                    Console.WriteLine(chiboger.name);
                    chiboger.Move(i * (here.Size.Width / 4), 120);
                    i++;
                }
                hp.bar.Delete();
            }
            public void Renew() { chibogerEffect.cooldown = chibogerEffect.duration; }
            public void Move(int x, int y) {
                skin.Location = new Point(x, y);
                hp.bar.Move(x, y - 13);
            }
            public abstract int GetDef();
        }
        public class GordonRamsay : Chiboger {
            public override string name { get { return "Gordon Ramsay"; } }
            public GordonRamsay() {
                hp = new HP(45, 0, 0, this);
                Move(50, 50);
                skin.Image = Properties.Resources.Gordon;
                skin.SizeMode = PictureBoxSizeMode.StretchImage;
                skin.Size = new Size(60, 50);
                here.Controls.Add(skin);
                chibogerEffect = new Effect(() => {
                    here.enemyDef -= 30;
                    here.enemyMultiplier -= .3f;
                }, 3);
                Renew();
            }
            public override int GetDef() { return 30; }
        }
        public class GuyFieri : Chiboger {
            public override string name { get { return "Guy Fieri"; } }
            public GuyFieri() {
                hp = new HP(65, 0, 0, this);
                Move(50, 50);
                skin.Image = Properties.Resources.Guy;
                skin.SizeMode = PictureBoxSizeMode.StretchImage;
                skin.Size = new Size(60, 50);
                here.Controls.Add(skin);
                chibogerEffect = new Effect(() => {
                    here.enemyHP.Damage((int)(30 * here.playerMultiplier));
                }, 3);
                Renew();
            }
            public override int GetDef() { return 30; }
        }
        public class BobbyFlay : Chiboger {
            public override string name { get { return "Bobby Flay"; } }
            public BobbyFlay() {
                hp = new HP(40, 0, 0, this);
                Move(50, 50);
                skin.Image = Properties.Resources.Bobby;
                skin.SizeMode = PictureBoxSizeMode.StretchImage;
                skin.Size = new Size(60, 50);
                here.Controls.Add(skin);
                chibogerEffect = new Effect(() => {
                    here.playerHP.Damage((int)(-30 * here.playerMultiplier));
                }, 3);
                Renew();
            }
            public override int GetDef() { return 30; }
        }
        public class JamieOliver : Chiboger {
            public override string name { get { return "Jamie Oliver"; } }
            public JamieOliver() {
                hp = new HP(55, 0, 0, this);
                Move(50, 50);
                skin.Image = Properties.Resources.Jamie;
                skin.SizeMode = PictureBoxSizeMode.StretchImage;
                skin.Size = new Size(60, 50);
                here.Controls.Add(skin);
                chibogerEffect = new Effect(() => {
                    here.playerDef += 30;
                }, 3);
                Renew();
            }
            public override int GetDef() { return 50; }
        }
        public class MichaelCaines : Chiboger {
            public override string name { get { return "Michael Caines"; } }
            public MichaelCaines() {
                hp = new HP(55, 0, 0, this);
                Move(50, 50);
                skin.Image = Properties.Resources.Michael;
                skin.SizeMode = PictureBoxSizeMode.StretchImage;
                skin.Size = new Size(60, 50);
                here.Controls.Add(skin);
                chibogerEffect = new Effect(() => {
                    here.playerMultiplier += .5f;
                }, 3);
                Renew();
            }
            public override int GetDef() { return 30; }
        }
        public class UncleRoger : Chiboger {
            public override string name { get { return "Uncle Roger"; } }
            public UncleRoger() {
                hp = new HP(40, 0, 0, this);
                Move(50, 50);
                skin.Image = Properties.Resources.Uncle;
                skin.SizeMode = PictureBoxSizeMode.StretchImage;
                skin.Size = new Size(60, 50);
                here.Controls.Add(skin);
                chibogerEffect = new Effect(() => {
                    here.luck += 20;
                }, 3);
                Renew();
            }
            public override int GetDef() { return 30; }
        }
        public class HP {
            public static List<HP> allHP = new List<HP>();
            public float current;
            public Bar bar;
            int max;
            int x;
            int y;
            bool isPlayer = false;
            Chiboger chiboger = null;
            public HP(int health, int x, int y, bool isPlayer) {
                this.x = x;
                this.y = y;
                Set(health);
                this.isPlayer = isPlayer;
            }
            public HP(int health, int x, int y, Chiboger chiboger) {
                this.x = x;
                this.y = y;
                Set(health);
                this.chiboger = chiboger;
            }
            public HP(int health, int x, int y) {
                this.x = x;
                this.y = y;
                Set(health);
            }
            //deal damage to entity
            public bool Damage(int damage) {
                Console.WriteLine($"Dealing damage {damage}");
                if (current - damage > max) { current = max; }
                else current -= damage;
                bar.Edit(current, max);
                //if dead
                if (current < 1) {
                    bar.Delete();
                    allHP.Remove(this);
                    Console.Clear();
                    if (chiboger != null) chiboger.Kill();
                    if (isPlayer) here.PlayerLose();
                }
                
                return current < 1;
            }
            public void Set(int health) {
                current = health;
                max = health;

                if (allHP.Contains(this)) return;
                bar = new Bar(x, y, 60, 13, health, health);
                allHP.Add(this);
            }
        }
        public class Bar {
            public int locationX, locationY;
            int sizeX, sizeY;
            float current;
            public int max;
            Label currentVisual;
            Label maxVisual;
            public Bar(int locationX, int locationY, int sizeX, int sizeY, float current, int max) {
                Console.WriteLine($"Made new HP bar {locationX} {locationY}");
                currentVisual = new Label();
                maxVisual = new Label();
                locationX -= sizeX / 2;
                locationY -= sizeY / 2;
                here.Controls.Add(currentVisual);
                here.Controls.Add(maxVisual);
                currentVisual.BackColor = Color.Green;
                currentVisual.ForeColor = Color.White;
                currentVisual.BorderStyle = BorderStyle.FixedSingle;
                currentVisual.Show();
                maxVisual.BackColor = Color.Red;
                maxVisual.BorderStyle = BorderStyle.FixedSingle;
                maxVisual.Show();
                this.locationX = locationX;
                this.locationY = locationY;
                this.sizeX = sizeX;
                this.sizeY = sizeY;
                this.current = current;
                this.max = max;
                Edit(current, max);
            }
            public void Edit(float current, int max) {
                this.current = current;
                this.max = max;
                currentVisual.Text = $"{current}/{max}";
                currentVisual.Size = new Size((int)(sizeX * (current / max)), sizeY);
                currentVisual.Location = new Point(locationX, locationY);
                maxVisual.Size = new Size((int)(sizeX * (1 - (current / max))), sizeY);
                maxVisual.Location = new Point(locationX + (int)(sizeX * (current / max)), locationY);
            }
            public void Delete() {
                here.Controls.Remove(currentVisual);
                here.Controls.Remove(maxVisual);
                currentVisual.Dispose();
                maxVisual.Dispose();
            }
            public void Move(int x, int y) {
                locationX = x;
                locationY = y;
                currentVisual.Location = new Point(locationX, locationY);
                maxVisual.Location = new Point(locationX + (int)(sizeX * (current / max)), locationY);
            }
        }
        public class Player
        {
            public static Player current;
            private int atkPower;
            private int defense;

            public Player()
            {
                current = this;
                AttackPower = atkPower;
                Defense = defense;
            }
            public int AttackPower
            {
                get { return atkPower; }
                set { atkPower = value; }
            }
            public int Defense
            {
                get { return defense; }
                set { defense = value; }
            }
        }
        public class Enemy
        {
            //private string enemyname; // this too (dont mind this as well) 
            private int atkPower;
            private int defense;

            //public string EnemyName
            //{
            //    get { return enemyname; } Add this if there is time to add it
            //    set { enemyname = value; } (Do not mind this sir if we forget to remove this comment)
            //}

            public int AttackPower
            {
                get { return atkPower; }
                set { atkPower = value; }
            }
            public int Defense
            {
                get { return defense; }
                set { defense = value; }
            }
        }
    }
}
