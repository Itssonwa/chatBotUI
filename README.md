Buck is now a WPF chatbot designed to answer cybersecurity questions,
recognise user sentiment, provide safety tips and maintain conversation context for follow-up questions.

How to Run
Open the solution in Visual Studio.
Restore the NuGet packages.
Build the project.
Run the application.
Interact with Buck using the chat box, task manager, or quiz.

The app works by writing any cybersecurity question in the white textbox, then press the green "SEND" botton to get an answer.
Once you're done using the app, just push the orange "FIN" button to close the app.

Cybersecurity knowledge now includes:
-Phishing
-Malware
-VPNs
-Firewalls
-Password safety
-Online scams
-Privacy protection

Can recognise sentiment based on words like:
-Worried
-Curious
-Frustrated

The chatbot records important actions including:
Questions answered
Tasks added
Tasks completed
Tasks deleted
Quiz started
Quiz completed

Users can view the activity log by typing:
[Show activity log]
[What have you done for me?]

The chatbot displays five entries at a time and allows the user to type show more to continue viewing the log.

Cybersecurity quiz
Topics include:
Phishing
Password Security
VPNs
Firewalls
Malware
Social Engineering
Privacy
Backups
Two-Factor Authentication

featuring:
More than 10 questions
Multiple-choice questions
True/False questions
Immediate feedback after each answer
Final score and personalised message at the end

Users can manage cybersecurity-related tasks by:
Adding new tasks
Viewing existing tasks
Marking tasks as completed
Deleting tasks
Setting optional reminders
All tasks are stored permanently in a SQLite database.
