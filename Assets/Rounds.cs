//Main chunk of code for game
//Changes to be made:
//add changes to judges faces when you get an answer wrong
//add changes to screen to show loss of points and/or flash red/green when right or wrong
//add start screen and start button and restart button and instructions
//possibly add distractions
//make ai more presentable
//experiment to give players more time (probably different reduction equation)
//
//bugs:
//skips round 9
//location of text is wak
//html thingy is stupid
//maybe: unsure if answers are correctly being chosen
//weird warnings in the console I don't care much about
//first round is occasionally weird with text


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rounds : MonoBehaviour
{
	public int rounds;
	//static means it can be accessed in other scripts
	public static float choice;
	public static int question;
	public static bool over;
    public static bool judgesHappy;
    public GameObject Distraction;
    public Sprite cleaner;
    public Sprite UFO;
    float addOrNot;
	Text roundNum;
	float interval;
	bool start;
	bool warn;

//array of potential questions: order matters
//see line 123 if you add questions
string[] q = {
"How do you do in front of the camera?",
"What is your approach to acting in general?",
"How do you work with other actors, as well as crew and directors?",
"How do you feel about being included in promotional materials?",
"How would you describe your work ethic?",
"Do you know how to sing?",
"How many languages can you speak?  Your character may need to speak non-English languages.",
"How athletic/healthy is your lifestyle?  We want our actors as physically fit as possible.",
"You may need to dance for your role.  How experienced are you at dancing?",
"What is your favorite part of acting?",
"Where do you see yourself in 5 years?",
"How long have you been acting for?",
"We may need you to be flexible in terms of where you are working.  Every so often, you may have to travel around the country or even to other countries.",
"How far away do you live from the place where we are filming?",
"Depending on how much budget we have, we might get a cameo from a big-name actor, like Merly Streep or Dwayne the Rock Johnson. How do you act around big names?",
"Do you feel frustrated that you are not a famous star?",
"How do you research and approach a new role?",
"Your character may have a foreign accent.  How experienced are you in imitating foreign accents?",
"What do you think of the acting community?",
"Obviously, acting for various roles involves a lot of flexibility.  No two characters are exactly alike.  How do you handle this?",
"Obviously, acting for various roles involves a lot of flexibility.  No two characters are exactly alike.  How do you handle this?",
"If you were given a 5 minute break during rehearsal, how would you spend that time?",
"Actors are required to memorize scripts.  Is this something that you think you could handle?",
"Everyone experiences setbacks at some point in time.  How would you handle one?",
"Tell me about your education.",
"What do you think of working long hours?  It often takes a lot of endurance.",
"How would you like to improve as an actor?",
"If you could create a play or movie about anything, what would be the topic?",
"When you want to practice acting, where do you go?",
"How would you define success in this career?",
"What do you think the most important quality of a director is?",
"What do you feel is more important as an actor: talent or training?",
"How do you react when you receive a negative review on your performance?",
"What does your ideal Sunday look like?",
"What have you done to improve your knowledge of acting in the last year?",
"Tell me about a time you had to think strategically?",
"Tell me about a time you disagreed with someone at work.",
"How would your friends describe you?",
"Tell me about a time that you faced an emergency.  How did you handle it?",
"How would you rehearse a scene if your scene partners are not around?",
"What have you learned from actors who have more experience?"
};

string[] yes = {
"I do takes consistently well, but am able to take director’s notes!",
"I try to get into the headspace of my character, through mental, emotional, and physical methods",
"I can be pretty shy between takes, but I treat coworkers with respect and get my job done well",
"Anything goes, no matter how I’m portrayed!",
"I work hard and always show up to work on time.  Whenever I am on set, I am giving 100% effort.  I only call off work when there’s an emergency.",
"No, I cannot sing.  I am eager to learn how and am willing to spend my free time practicing.",
"I am fluent in English and can speak a little bit of German.",
"Every morning, I manage to find time to go for a good run.",
"I have been dancing since I was 8 years old.  I took a break for several years during university, but now I have been practicing again.",
"I really enjoy the freedom that comes with acting.  I can be whomever I want to be, as long as there’s a role for it.  The escape from reality has fascinated me… ever since I was a young child.",
"I hope to continuously improve my acting career.  Over the next 5 years, I want to gain as much acting experience and knowledge as possible.  While I may not become the most famous actor, I want to have a very successful career in this field.",
"I have been acting for my whole life.  I have been doing it ever since I can remember, and my passion for it is still going strong.  I still enjoy it as much as I did when I started.",
"Yes, I can be flexible.  I love visiting new places and this sounds like a perfect opportunity for me to do so.",
"I live about 10 miles away, but I have access to a car, so it should take 15 minutes and I can help with any other transportation",
"I try to act as professionally as possible, on and off camera, even if my mind is going into overdrive!",
"I am not famous… yet!  I hope to have a successful career and we’ll see where that takes me.",
"If this character was a real person, I typically do some online research about their history.  If the character is fictitious, I read the script more than once, attempting to internalize their personality.  After that, I take a walk to clear my head and put myself in the right mental state for acting.",
"Accents are something that I have to work very hard at.  After years of work with my accent coach, I have perfected 2 different English accents and 5 different non-English accents.",
"I love the acting community!  The people here are the absolute nicest people I have ever met.  Most of my friends are into acting, and it helps us form strong connections with each other.  This community is one of the reasons I enjoy acting so much in the first place.",
"I am great at adapting to new roles.  As long as I get into the right mental state, I find that no matter the character I am playing, it is easy to replicate their behavior.",
"I am great at adapting to new roles.  As long as I get into the right mental state, I find that no matter the character I am playing, it is easy to replicate their behavior.",
"5 minutes is not that long, so I’d spend some of the time relaxing and the rest of the time quickly thinking about my work plan for after the break",
"Memorizing scripts is not easy, but I can handle it!  I have memorized many scripts throughout my career and can still recite them when needed.",
"Setbacks are always disheartening and disappointing, but we simply have to accept them.  Letting a setback drag me down will impact my future progression, so I would reflect on what I should have done differently and move on with life.",
"In high school, I participated in theater.  At university, I earned a degree in drama.",
"Acting is my passion, so I am plenty happy to work for most of the day.",
"I wish I was better at playing comedic characters.  I have more experience playing serious characters, so I have a harder time playing a comedic character.",
"I love the history of this country and think that there are many stories about its founding that would become a good play or movie.",
"My friend and I simply meet up at my house and we practice there together.  We don’t need a fancy place to practice!",
"Well, that’s difficult to define.  Success can come from a variety of sources.  However, I think the most important one is the amount that my work positively impacts the world.  The more my work helps the world, the more successful I am!",
"I think compassion goes a long way.  Being understanding of my situation certainly helps me out, and overall improves my performance at work.",
"I think that training is the most important part of being an actor.  While talent is important, training allows an actor to adapt and learn to any situation.",
"It makes me unhappy, but I understand that I am not flawless.  Every bit of input I get makes me a better actor in the long run!",
"I work very hard throughout the week, and love to relax!  I often go for walks and occasionally spend the weekend camping in nature.",
"I like to observe and learn from other actors.  I talk to my friends who are into acting and try to learn from their strengths.",
"Once, we were very limited on staff--even our supervisor was absent.  I had to make sure to assign people roles that would best suit their strengths, and ensure that every job was accounted for.",
"I was told that we needed more extras for our movie.  I thought that this was excessive and would impact our budget.  We ended up compromising and hiring only a few extra actors.",
"My friends say that I have a great work ethic and they always remark on my extreme passion for acting.",
"I was rehearsing with a co-worker when he fell and hit his head.  He was unconscious, so I called 911 and followed their instructions while waiting for the ambulance.",
"My ability to act is not impacted by my surroundings.  To act is to pretend, and it is quite easy to perform no differently whether or not my scene partners are actually in the room.",
"I learned that nobody is a perfect actor.  Even actors who have a lot of experience are constantly working to improve themselves.  As someone with less experience, I have a long way to go!"
};

string[] no = {
"I get shy in front of cameras and often miss my marks for staging",
"I often go off script or improvise based on what I feel I would do in the character’s situation.",
"I’m very outgoing and sociable, but shoots take longer as its harder to get me refocused after we cut",
"I won’t do it unless I discuss with my lawyer!",
"I work hard!  Typically, I’m only a few minutes late to work.  I may require more breaks than my co-workers, but I do put in effort during the work day.",
"Yes, I can sing.  I am a sub-par singer and have little passion for music.",
"I am fluent in English and can fluently understand Spanish and Chinese.",
"I exercise for 30 minutes every day.  I run around the neighborhood, do push ups, and lift weights.  After every workout, I consume a fast food meal fit for three people.  Who knows why I keep gaining weight…",
"I really love dancing, and I have been practicing for the last year.  I am a rather casual dancer and my skills are far from professional level.",
"Acting is the only thing that I have ever been good at.  How else will I pay the bills?",
"I have been acting all of my life.  It is something that I enjoy, and have been enjoying ever since I could remember.  However, I also have been doing other activities like animation and music production on the side.  I like acting, but in 5 years I may move on with my career.",
"I have been acting for as long as I can remember.  I started when I was 8 years old, in a school play.  My acting career took a long break from high school through college, but recently I began to find interest in it again.",
"Yes, going to new places sounds great!  Is this like a vacation?  Will I be able to work less after I’ve travelled there?",
"I live 3 miles away, but I have to walk over/need to be picked up in order to arrive on set.",
"I drool at the mouth and hound them for an autograph. I mean, c’mon, they’re stars!",
"Yeah, it can be frustrating.  Everyone hopes to make it big and I’m no exception.  Man what I would do for that…",
"I jump right into the role.  Researching takes time, and that time is better spent with practice in my opinion.  I may not be able to perfect the role, but I’m a bit quicker when we get started without preparation.",
"Foreign accents are something that come naturally to me.  I can speak in an Australian accent quite easily, but I’ve never tried to imitate anything else.",
"I get along very well with the community.  I very rarely make friends with other people who like acting, but I can work with them in a professional setting.",
"I’m very used to playing the main villain.  I’ve done it so much that I’m extremely good at it.  I can switch between villain roles with ease.  However, I feel out of my element when I try to play any other role.",
"I’m very used to playing the main villain.  I’ve done it so much that I’m extremely good at it.  I can switch between villain roles with ease.",
"I would go for a walk.  It helps clear the mind, but I may not return on time",
"My favorite part of acting is improv since I’m not particularly good at memorizing anything.  Often, I find memorizing scripts to be boring and detrimental to the acting experience",
"As with many people, setbacks make me incredibly angry.  No setbacks are acceptable since they are a sign of weakness.  I don’t deal with setbacks because they rarely happen to me.",
"From an academic standpoint, I did a lot of my acting in high school drama class.  At university, I decided to pursue computer science instead.",
"Acting is my favorite thing in the world to do.  So, you would expect that I could act for a long time… but honestly I get burnt out really quickly.",
"After a hard day of acting, I often become a bit grumpy.  This negatively impacts both my acting ability and my interactions with co-workers, so I’d like to improve by remaining cordial throughout the day.",
"I would create an autobiographical film.  As an upcoming star, I want to document my rise to fame… mostly to show off how great I am and to intimidate the competition.",
"I typically go to the nearest Starbucks and order a coffee with a friend.  Then, we practice our acting skills in the middle of the store to make sure the other customers can see how amazing our skills are.",
"Success is very easy to measure in the acting career!  Every dollar an actor earns is proportional to his or her success.  The only good actors are the ones whose careers lead them to millions of dollars.",
"The best quality of a director is having a huge budget.  The larger the budget, the bigger the project we can work on… and the more you can pay me.",
"Talent is the most important part of being an actor.  I am so unbelievably talented that I have never needed to train.  Everything comes effortlessly to me and I am the perfect actor for this role.",
"I get very angry.  How dare they insult my acting ability!",
"I like to watch movies over the weekend!  To be honest, I’m a bit of a hypocrite because I usually pirate my movies.",
"I hang out with my friends who like acting.  I like to think that their acting knowledge will magically rub off into my brain, so I have to do very little work",
"Once, I had to think about what to eat for lunch and dinner.  If I ate the pizza for lunch, then I won’t have pizza for dinner… but if I ate the pizza for dinner, then I won’t have pizza for lunch…",
"I was taking a break while my co-workers were rehearsing.  I was told that I was too noisy, but obviously I wasn’t!  How very rude of them to suggest that.",
"My friends don’t have any opinions about me.  That’s because… I have no friends.",
"I once noticed a thief stealing from our studio.  None of the items were personally mine, so I let the thief go.",
"This has actually happened to me before.  I ended up taking the day off.  What is the point of practicing when I’m all alone?",
"Considering how much more experience they have, I learned that I am quite good at acting.  I am just as good as them, even despite my lesser experience."
};





    // Start is called before the first frame update
    void Start()
    {
		start = false;
		MainText.output.text = "Press the left or right arrow key to start";
		rounds = 10;
		SC_CountdownTimer.countdownInternal = 0;
        roundNum = GetComponent<Text>();
        roundNum.text = "Round: " + rounds.ToString();
		warn = false;
    }
	//added to make start/restart much easier
	void initiate()
	{
		//x.variable means variable in script x
		//set values to initial condition
		//some stuff here is useless, but don't delete anything
		SC_CountdownTimer.countdownOver = false;
		SC_CountdownTimer.countdownInternal = 20;
		SC_CountdownTimer.countdownTime = SC_CountdownTimer.countdownInternal;
		Score.score = 0;
		roundNum = GetComponent<Text>();
        roundNum.text = "Round: " + rounds.ToString();
		rounds = 10;
		rounds = rounds + 1;
		over = false;
		//amount of time that is subtracted after each round
		//currently linear, maybe try non-linear
		interval = SC_CountdownTimer.countdownTime / (rounds);
		MainText.output.text = "";
		newRound();
	}


    // Update is called once per frame
    void Update()
    {
		//used to call game over
		//if left arrow pressed, game will restart
		if (rounds == 0)
		{
			endstate();
			if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
			{
				initiate();
				start = true;
			}
			return;
		}
		if (((SC_CountdownTimer.countdownInternal / SC_CountdownTimer.countdownTime) >= .2) && ((SC_CountdownTimer.countdownInternal / SC_CountdownTimer.countdownTime) <= .25))
            {
                if (!warn)
				{
					warn = true;
					StartCoroutine(changeBackground(253f, 218f, 13f));
				}
            }
		//used to indicate selection of score, add/subtract points, and move to next round
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			if (!start)
			{
				initiate();
				start = true;
				return;
			}
			if (choice > .5)
			{
				updateScore(2);
                StartCoroutine(changeBackground(80f, 200f, 120f));
                judgesHappy = true;
			} else {
				updateScore(-1);
                StartCoroutine(changeBackground(238f, 75f, 43f));
                judgesHappy = false;
			}
			newRound();
            if (rounds != 0) { StartCoroutine(addDistraction()); }
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			if (!start)
			{
				initiate();
				start = true;
				return;
			}
			if (choice > .5)
			{
				updateScore(-1);
                StartCoroutine(changeBackground(238f, 75f, 43f));
                judgesHappy = false;
			} else {
                updateScore(2);
                StartCoroutine(changeBackground(80f, 200f, 120f));
                judgesHappy = true;
			}
			newRound();
            if (rounds != 0) { StartCoroutine(addDistraction()); }
		}
		//if countdown finishes
		if (SC_CountdownTimer.countdownOver && start)
		{
			SC_CountdownTimer.countdownOver = false;
			SC_CountdownTimer.countdownInternal = SC_CountdownTimer.countdownTime;
			Score.score -= 100;
			newRound();
		}
    }

    // changes backgrounud color then reverts it background
    IEnumerator changeBackground(float x, float y, float z)
    {
		Camera.main.GetComponent<Camera>().backgroundColor =
            new Color(x / 255f, y / 255f, z / 255f);
        yield return new WaitForSeconds(0.25f);
        Camera.main.GetComponent<Camera>().backgroundColor =
            new Color(55f / 255f, 77f / 255f, 118f / 255f);
    }

	//initiates a new round
	//called after each button press
	void newRound()
	{
		rounds = rounds - 1;
		MainText.output.text = "";
		pickText();
        if (rounds != 0) { StartCoroutine(addDistraction()); }
		warn = false;
		Score.output.text = "Score: " + Score.score.ToString();
		roundNum.text = "Round: " + rounds.ToString();
		SC_CountdownTimer.countdownTime -= interval;
		SC_CountdownTimer.countdownInternal = SC_CountdownTimer.countdownTime;
	}

    // add distraction into play field
    IEnumerator addDistraction()
    {
        addOrNot = (Random.value);
        if (addOrNot < 0.1) {
            Distraction.GetComponent<SpriteRenderer>().sprite = UFO;
        } else if (addOrNot > .9) {
            Distraction.GetComponent<SpriteRenderer>().sprite = cleaner;
        } else {
            Distraction.GetComponent<SpriteRenderer>().sprite = null;
        }

        yield return new WaitForSeconds(1.25f);
        Distraction.GetComponent<SpriteRenderer>().sprite = null;
    }

	//places right/wrong answer on certain sides of the screen
	void pickText()
	{
		choice = (Random.value);
		question = Mathf.RoundToInt(Random.value * 39);
		Question.output.text = q[question];
		if (choice > .5)
		{
			ChoiceB.output.text = no[Rounds.question];
			ChoiceA.output.text = yes[Rounds.question];
		} else {
			ChoiceB.output.text = yes[Rounds.question];
			ChoiceA.output.text = no[Rounds.question];
		}
	}
	//don't touch
	void updateScore(int mult)
	{
		Score.score += mult*100*Mathf.RoundToInt(SC_CountdownTimer.countdownInternal)
                    / Mathf.RoundToInt(SC_CountdownTimer.countdownTime);
	}
	//game over screen
	void endstate()
	{
        if (Score.score > 800) {
            Question.output.text = "";
    		ChoiceA.output.text = "";
    		ChoiceB.output.text = "";
    		Score.output.text = "";
			judgesHappy = true;
    		SC_CountdownTimer.countdownInternal = 0f;
    		MainText.output.text = "You Win! " + Score.score + " Points";
    		start = false;
        } else {
            Question.output.text = "";
    		ChoiceA.output.text = "";
    		ChoiceB.output.text = "";
    		Score.output.text = "";
			judgesHappy = false;
    		SC_CountdownTimer.countdownInternal = 0f;
    		MainText.output.text = "Game Over: " + Score.score + " Points \nPress an Arrow Key to Try Again";
    		start = false;
        }
	}

}
