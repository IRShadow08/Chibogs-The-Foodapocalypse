using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Chibogers_TheFoodpocalyse_1._0._0;

namespace Storytelling
{
    internal class Story: Form
    {
        static string[] GetStory = StoryScript();
        private Timer timer1;
        private System.ComponentModel.IContainer components;
        private Label Dialogue;

        public static string[] StoryScript()
        {
            //Introduction once the game starts(you run the windows)
            string Introd = "It is a peaceful day where everyone was going on by their daily lives;However..;A sudden loud noise came crashing into the earth’s atmosphere as the skies have turned red.;A meteor had fell off to the earth that caused a huge shockwave…;And all of the sudden… plants, insects, and animals started mutating and began attacking humans;And on the brink of humanity its up to the MC(Masterchef Chibogs) and the Chiboggers to fight off these “Metamorphs”;To save the world? Or to Survive?";
            
            //once you play Start the Game
            string P1 = "Everything is in chaos;you can hear outside the window of your apartment that people are screaming and are being chased by oddly weird looking creatures that resembles a plant, insect, and animals;and all of the sudden a mutated cow bursts into your door;YOU: Wha… WHY IS THERE A WEIRD COW IN THIS BUILDING?";
            string P2 = "After managing to outwit the oddly looking cow, you run as fast as you can to get out of the room and locked the door behind you;You heard a grunt beside you;As you turn around you immediately are faced with multiple mutated plants staring at you;YOU: AHHH!!!;As you ran you kept on attracting more metamorphed plants and FISHES?’;YOU: WHY IS THIS HAPPENING TO ME??;And now you have to break through multiple of them to escape the building";
            string P3 = "After breaking through them, you managed to run into a dark alley where it looks like no weird looking mutants are lurking…;YOU: Breaths Heavily*;YOU: I cant… there is so many! What is happening in this world??? ;You stopped and quickly analyze your surroundings hoping to get an answer;Checking your phone and you where shocked by the amount of news about the situation and began checking them one by one;Apparently these mutated creatures are called metamorphs, they are any living organisms that where affected by the shockwave of the meteor and for unknown reason it doesn’t affect us humans;However… man-made weaponry had no effect on these metamorphs and just told everyone to hide and not to engage with them until “cure” is found.;After reading you have come up to your senses and began to calm down and think;YOU: looks like I’ll need to hide for now;All of the sudden, you felt something that touched your shoulder";
            string P4 = "You screamed as you swiftly strike it away;YOU: AHHHHHHH!!;You felt stupid when you realized that it was just a branch from a wall;YOU: Wait… Why is there a branch in this wall?;Looking closely, it looked like there is a noticable gap in between the branch which you tried to push it;Nothing seems to be happening yet you tried to push it harder, and it suddenly barged all the way that leads to an underground tunnel;YOU: this looks oddly suspicious but this is better than trying to survive in the surface";
            string P5 = "You went inside the underground tunnel that looked like someone used to live here;There’s an old tv, a sofa with a carpet beside it, a fridge, some books;YOU: Wait a fridge! There is probably some goodies here ;You were welcomed by a punget smell;YOU: Ack! What did I expect… this looked like abandoned in years;YOU: On the Bright side, I now have a safe base to go back to.;YOU: Aight lets get to fixing and cleaning up this place to call it my home;Nearby, you saw some cleaning materials like a broom and a brush, and the faucet here is working and began cleaning and tidying things up.;While cleaning, when you lift the carpet you saw a hatch door;YOU: an underground tunnel with another underground tunnel?";
            string P6 = "You saw a weird looking lock, and realized you ca  n’t force it to open, and began looking for “tools” to open/break it;But to no avail the lock seemed indestructible…;You left it for now, and finished your base cleaning first;YOU: Finally! Finished cleaning, but I still wonder whats inside of that hatch;YOU: But I still need to gather food first;YOU: Well I guess its time to get food first and… head outside again..";
            string P7 = "Years have passed…;You can no longer see anyone on the streets besides the metamorphs, and the signal and internet is now down;And you are still on the same routine: eat, Fix Base, Gather resources and food when needed, Go back home, eat,  try to open the hatch, workout when done, then sleep;However, everytime you tried to open the hatch it always doesn’t break or seemed like its taking damage;And you can’t break the hatch itself because it is made up of well coated concrete that looked like has hard steel frames, and forcing it to open could make too much noise that could led metamorphs to my base;Feeling tired, you are now curious and finally tried to check the books if there’s something interesting in them;However, the words seems like its not in english nor you have seen before, as you check the other pages…;You where shocked yet ecstatic as you see a weird looking key that is placed on tha pages that has been etched that became the holder for the key;YOU: This might be it!";
            string P8 = "*Click*;The lock opens and you began openning it with all your might because of how heavy the hatch is, and as you openned it…;YOU: wait that’s it?;In front of you is just some plain old glasses;But suddenly you realized that maybe it had something to do with those books;You wore it, and it is just like a lensless glasses, but when you tried reading the pages of the book. Suddenly you can understand them like its in english!;You began wearing and taking it off checking if your mind is just playing tricks on you, but it doesn’t.;You are shocked because the contents of it is like someone already studied these metamorphs before and it is so well documented that it is frightening, because it looked like someone already had encountered with them;According to the book, the Chibog Chef wrote this book and is the only that lead the chiboggers to fight off these metamorphs.;You read further in the pages and it explains the weaknesses of each metamorph and there is a noticable pattern depending on which they came from, for examble in green plants it is always on the bottom of their body, and for range plants its on the top side of their body;It would have been easy if its not the most protected place of each one…;There are recipes on which these ingredients came from them and some can weaken them, poison them, and most important of all, inflict damage on them and further increase the damage you inflicted them with.;Something piqued your interest… ;YOU: It is said here that we can actually make food out of them and they are safe to eat.. atleast according to the book…;You are also getting desperate because food is now scarce, and you have no choice but to risk it or just wait till eventually you can no longer find food and die.;You sat there studying the books for a long time and practice aiming on the “patterns”;A month has passed and now you don’t have anymore food to eat, and had no choice but to fight and gather resources from them instead.;YOU: I guess… it’s now or never!";
            string P9 = "Months has passed since you have last read the book, and now you have mastered every pattern, every craftables and every recipes by instinct.;YOU: And honestly at first, looking at them and eating them looks like it could kill you from poisining;YOU: However, after killing them and trying to cook them, it surprisingly turned them back into their original form and it is oddly quite fresh;YOU: After eating them, the tasted delicious and the best part is it doesn’t affect my stomach in any way!;YOU: If only I could tell this to anyone but sadly the signal has been dead for a long time;And now you only have one more choice, and it is to find for survivors and teach them how to survive in this apocalypse and to fight off these metamorphs;Slowly but surely you were finding survivors and now they follow you, The great Chibog Chef! And them the Chiboggers who will always be loyal to you and go wherever you go.";
            string P10 = "Years have passed, and now your numbers have grown a lot, and now you are deciding;YOU: My Chiboggers, I think… no, I am sure we can win amidst these chaos and finally no longer hide from these metamorphs.;YOU: I say we destroy their source… and it is that very meteor that fell off this Earth when the metamorphs started to mutate, they say it is indestructible but I know the patterns but oh boy theres a lot of it...;YOU: I know it is too much for me to ask because I know everyone just wants to live and survive;YOU: But I won’t let these metamorphs takes what is ours! And as the Chibog Chef it is my duty to protect every chiboggers, and defeat these metamorphs;YOU: It is your choice, to stay here or to join me in my journey and I promise you, if you join me I will guarantee you that we will no longer take back what is ours, and its FREEDOM!;YOU: So, who wants to join me?;Someone: You save us when we needed help, and now it is time to payback and help you in this journey!;One agreed until eventually everyone agreed and now everyone is shouting to join!;YOU: That’s what I’d like to hear!;YOU: Prepare you tools, your weapons, your everything because we will embark in this long journey for the quest of freedom";
            string[] story = { Introd, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10 };
            return story;
        }
        static void Running(string[] args)
        {
            Application.Run(new Story());
        }

        public Story() { InitializeComponent();}

        private void InitializeComponent()
        {
            Text = "Story";
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Dialogue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Dialogue
            // 
            this.Size = new System.Drawing.Size(600, 100);
            this.Dialogue.AutoSize = true;
            this.Dialogue.Location = new System.Drawing.Point(0, 0);
            this.Dialogue.Name = "Dialogue";
            this.Dialogue.Size = new System.Drawing.Size(30, 100);
            this.Dialogue.TabIndex = 0;
            // 
            // Story
            // 
            this.Controls.Add(this.Dialogue);
            this.Name = "Story";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Program_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        //depending on level would trigger the dialogue
        int level = 0, j = 0, k=0;
        bool complete = true;
        bool Temp = true;

        // GetStory = { words, words }
        void timer1_Tick(object sender, EventArgs e)
        {

            if (level < GetStory.Length)
            { //number of paragraphs
                string[] StoredStory = GetStory[level].Split(';'); //number of words inside the p
                if (j < StoredStory.Length)
                {
                    if (k < StoredStory[j].Length)
                    {
                        Dialogue.Text += StoredStory[j][k++];
                        complete = false;

                        if (Dialogue.PreferredWidth >= this.ClientSize.Width && Temp)
                        {
                            Dialogue.Text = Dialogue.Text.TrimEnd();
                            Dialogue.Text += Environment.NewLine;
                            Temp = false;
                        }
                    }
                    else
                    {
                        k = 0;
                        j++;
                        complete = true;
                        Temp = true;
                        timer1.Stop();
                    }
                }
                else
                { this.Close();}
            }
        }
        //To continue the script or skip
        void Program_KeyDown(object sender, KeyEventArgs e)
        {
            if (complete) 
            {
                Dialogue.Text = "";
                if (e.KeyCode == Keys.Enter) timer1.Start();
            } 
            else 
            {
                Dialogue.Text = GetStory[level].Split(';')[j++];
                k = 0;
                timer1.Stop();
                complete = true;
            }
        }

    }
}
