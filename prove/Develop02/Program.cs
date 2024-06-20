using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        LoadJournal(ref journal);
        RunProgram(ref journal);
    }
    static void RunProgram(ref Journal journal){
        bool loop = true;
        while(loop){
            // Console.Clear();
            ShowMenuPrompts();
            int menuChoice = GetUserInput();
            if(menuChoice == 5){
                loop = false;
            }else{
                DoMenuPrompt(menuChoice, ref journal);
            }
        }
    }
    static void ShowMenuPrompts(){
        Console.WriteLine(@"
1. Write a new entry. 
2. Display your journal.
3. Save your journal.
4. Load your journal.
5. Exit.");
    }
    static int GetUserInput(){
        return int.Parse(Console.ReadLine());
    }
    static void DoMenuPrompt(int input, ref Journal journal){
            switch(input){
                case 1:
                    journal.AddEntrytoJournal(ref journal);
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                    break;
                case 2:
                    journal.Display(journal);
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                    break;
                case 3:
                    journal.SaveJournal(journal);
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                    break;
                case 4:
                    int checkForFile = LoadJournal(ref journal);
                    if(checkForFile == 0){
                        Console.WriteLine("No journal currently exists.");
                    }
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Error: Wrong Input");
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                    break;
            }
    }

    static int LoadJournal(ref Journal journal){
        string fileName = "Journal.csv";
        if(System.IO.File.Exists(fileName) && !string.IsNullOrWhiteSpace(System.IO.File.ReadAllText(fileName))){
            journal = journal.ReadJournal();
            return 1;
        }
        else{
            return 0;
        }
    }
}
public class Journal{
    public List<Entry> entries = new List<Entry>();

    public void AddEntrytoJournal(ref Journal journal){
        Entry entry = Entry.CreateNewEntry();
        journal.entries.Add(entry);
    }
    public void Display(Journal journal){
        foreach(Entry entry in journal.entries){
            Console.WriteLine($"{entry._entryDate} \n{entry._prompt} \n {entry._content} \n\n");
        }
    }
    public void DisplaySpecificEntry(){
        // Maybe I'll do this, I don't know yet.
    }
    public Journal ReadJournal(){
        string fileName = "Journal.csv";
        string[] lines = System.IO.File.ReadAllLines(fileName);
        List<Entry> entryList = new List<Entry>();
        foreach(string line in lines){
            string[] parts = line.Split(",.,");
            Entry entry = new Entry(){
                _entryDate = DateTime.Parse(parts[0]),
                _prompt = parts[1],
                _content = parts[2]
            };
            entryList.Add(entry);
        }
        Journal journal = new Journal();
        journal.entries = entryList;
        return new Journal{entries = entryList};
    }
    public void SaveJournal(Journal journal){
        string fileName = "Journal.csv";
        using(StreamWriter output = new StreamWriter(fileName)){
            foreach(Entry entry in journal.entries){
                output.WriteLine($"{entry._entryDate},.,{entry._prompt},.,{entry._content}");
            }
        }
    }
}

public class Entry{
    public DateTime _entryDate;
    public string _content;
    public string _prompt;

    public static Entry CreateNewEntry(){
        Entry entry = new Entry();
        entry._entryDate = DateTime.Now;
        entry._prompt = GetPrompt();
        entry._content = GetPromptInput();
        return entry;
    }
    private static string GetPromptInput(){
        string answer = Console.ReadLine();
        return answer;
    }
    private static string GetPrompt(){
        Random rand = new Random();
        int promptIndex = rand.Next(1, 5);
        switch(promptIndex){
            case 1:
                Console.WriteLine("Who was the most interesting person I interacted with today?");
                return("Who was the most interesting person I interacted with today?");
            case 2:
                Console.WriteLine("What was the best part of my day?");
                return("What was the best part of my day?");
            case 3:
                Console.WriteLine("How did I see the hand of the Lord in my life today?");
                return("How did I see the hand of the Lord in my life today?");
            case 4:
                Console.WriteLine("What was the strongest emotion I felt today?");
                return("What was the strongest emotion I felt today?");
            case 5:
                Console.WriteLine("If I had one thing I could do over today, what would it be?");
                return("If I had one thing I could do over today, what would it be?");
            default:
                return "";
        }
    }
}