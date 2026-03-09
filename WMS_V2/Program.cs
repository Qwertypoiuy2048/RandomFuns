class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        string path = "C:\\Users\\ehcre\\.vscode\\projects\\MyProjects\\WMS.csv"; // Update this path to where your CSV file is located
        int num_of_possible_surges = 456; // Update this if you add more surges to the CSV file

        List<int> H_Surges = new List<int>();
        List<int> V_Surges = new List<int>();
        List<int> B_Surges = new List<int>();

        List<int> S1_Surges = new List<int>();
        List<int> S2_Surges = new List<int>();
        List<int> S3_Surges = new List<int>();
        List<int> S4_Surges = new List<int>();
        

        int round = 0;

        void readCSV(string filename)
        {
            Console.WriteLine($"Reading surge results from {filename}...");
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line;
                    int lineNumber = 1;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line); 
                        string[] parts = line.Split(',');
                        if (parts.Length != 3)
                        {
                            Console.WriteLine($"Invalid line format at line {lineNumber}. Skipping.");
                            continue;
                        } else
                        {
                            char severity = parts[0][0];
                            char type = parts[1][0];
                            string description = parts[2];
                            Surge surge = new Surge(severity, type, description, lineNumber);
                            if (severity == 'H')
                            {
                                H_Surges.Add(lineNumber);
                            } else if (severity == 'V')
                            {
                                V_Surges.Add(lineNumber);
                            } else if (severity == 'B')
                            {
                                B_Surges.Add(lineNumber);
                            }

                            if (type == '1')
                            {
                                S1_Surges.Add(lineNumber);
                            } else if (type == '2')
                            {
                                S2_Surges.Add(lineNumber);
                            } else if (type == '3')
                            {
                                S3_Surges.Add(lineNumber);
                            } else if (type == '4')
                            {
                                S4_Surges.Add(lineNumber);
                            }
                        }
                        lineNumber++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not open file {filename}");
                Console.WriteLine($"Please place a valid CSV file at '{path}'");
                Console.Write("Please confirm [y/n]: ");
                string response = Console.ReadLine();
                if (response.ToLower() == "y")
                {
                    readCSV(filename); // Try reading the file again
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Cast spell");
            Console.WriteLine("2. Force surge");
            Console.WriteLine("3. Reset used slots");
            Console.WriteLine("4. Force surge by type");
            Console.WriteLine("5. Increment round");
            Console.WriteLine("0. Quit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 0:
                    Console.WriteLine("Thank you for using my program!");
                    return;
                case 1:
                    // Implement casting spell logic here
                    break;
                case 2:
                    // Implement force surge logic here
                    break;
                case 3:
                    // Implement reset used slots logic here
                    break;
                case 4:
                    // Implement force surge by type logic here
                    break;
                case 5:
                    // Implement increment round logic here
                    Console.WriteLine("Was there a surge this round? (y/n): ");
                    string surgeThisRound = Console.ReadLine();
                    if (surgeThisRound == "y")
                    {
                        // Reset slots used
                    }
                    // Increment round counter
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        // void printSurgeResult(int i,struct surgeResult surge, char* buffer) {
        //     sprintf(buffer, "\n\nLine: %d \nSeverity: %c \nType: %c \nDescription: \n%s",i, surge.Type, surge.Severity, surge.Description);
        // }

        // void createSurgeResult(struct surgeResult* surge, char severity, char type, char* description, struct surgeResult* next) {
        //     surge->Severity = severity;
        //     surge->Type = type;
        //     strncpy(surge->Description, description, sizeof(surge->Description) - 1);
        //     surge->Description[sizeof(surge->Description) - 1] = '\0'; // Ensure null-termination
        //     surge->next = next;
        // }

        // struct surgeResult* readCSV(char* filename) {
        //     printf("Reading surge results from %s...\n", filename);
        //     FILE* fb = fopen(filename, "r");
        //     if (fb == NULL) {
        //         printf("Could not open file %s\n", filename);
        //         printf("Please place a valid CSV file at '%s'\nPlease confirm [y/n]: ", path);
        //         scanf("%d");
        //         exit(EXIT_FAILURE);
        //     }
        //     int positive_surges = 0;
        //     int negative_surges = 0;
        //     int variable_surges = 0;
        //     int cosmetic_surges = 0;
        //     int S1_surges = 0;
        //     int S2_surges = 0;
        //     int S3_surges = 0;
        //     int S4_surges = 0;

        //     struct surgeResult* head = NULL;
        //     struct surgeResult* current = NULL;

        //     printf("Opening file %s\n", filename);
        //     while (fgets(line, sizeof(line), fb)) {
        //         printf("%s", line); // Temp
        //         char* token = strtok(line, ",");
        //         if (!token) continue;
        //         char severity = token[0];
        //         token = strtok(NULL, ",");
        //         if (!token) continue;
        //         char type = token[0];
        //         token = strtok(NULL, ",");
        //         if (!token) continue;
        //         char description[300];
        //         strncpy(description, token, sizeof(description) - 1);
        //         description[sizeof(description) - 1] = '\0'; // Ensure null-termination

        //         struct surgeResult* new_node = malloc(sizeof(struct surgeResult));
        //         createSurgeResult(new_node, severity, type, description, NULL);

        //         if (head == NULL) {
        //             head = new_node;
        //             current = new_node;
        //         } else {
        //             current->next = new_node;
        //             current = new_node;
        //         }

        //         if (type == '1'){
        //         	S1_surges ++;
        //         }else if (type == '2'){
        //         	S2_surges ++;
        //         } else if (type == '3'){
        //         	S3_surges ++;
        //         } else if (type == '4'){
        //         	S4_surges ++;
        //         }

        //         if (severity == 'B'){
        //         	positive_surges ++;
        //         } else if (severity == 'V'){
        //         	variable_surges ++;
        //         } else if (severity == 'H'){
        //         	negative_surges ++;
        //         } else if (severity == 'C'){
        //         	cosmetic_surges ++;
        //         }
        //     }
        //     printf("\n\nS1: %d, \nS2: %d, \nS3: %d, \nS4: %d \n\nPositive: %d, \nVariable: %d, \nNegative: %d, \nCosmetic: %d", S1_surges, S2_surges, S3_surges, S4_surges, positive_surges, variable_surges, negative_surges, cosmetic_surges);
        //     printf("\n\nTotal: %d",num_of_possible_surges);

        //     fclose(fb);
        //     return head;
        // }



        // void triggerSurge(int line_num,struct surgeResult* head) {
        //     printf("A wild magic surge is triggered!\n");
        // //    printf("Slots used has been reset to 0.\n");
        //     int surge_roll = rand() % num_of_possible_surges + 1;
        //     struct surgeResult* current = head;
        //     for (int i = 1; i < surge_roll && current != NULL; i++) {
        //         current = current->next;
        //         line_num ++;
        //     }
        //     if (current != NULL) {
        //         char buffer[300];
        //         printSurgeResult(line_num,*current, buffer);
        //         printf("%s\n", buffer);
        //     } else {
        //         printf("Error: Surge roll out of bounds.\n");
        //     }
        //     int choice;
        //     while (1) {
        //         printf("press 1 to accept, or 2 to reroll: ");
        //         scanf("%d", &choice);
        //         if (choice == 2) {
        //             printf("Rerolling surge...\n");
        //             triggerSurge(1, head); // Reroll by calling the function again
        //             return;
        //         } else {
        //             return;
        //         }
        //     }
        // }

        // int rollSurge(int slots_used, struct surgeResult* head) {
        //     int roll = rand() % 20 +1;
        //     printf("You rolled a %d\n", roll);
        //     if (roll <= slots_used) {
        //         triggerSurge(1,head);
        //         return 0;
        //     } else {
        //         printf("No surge triggered. Chance to trigger is now: %d/20\n", slots_used);
        //         return slots_used;
        //     }
        // }

        // void resetSlots(int* slots_used) {
        //     *slots_used = 0;
        //     printf("Slots used has been reset to 0.\n");
        // }

        // int main() {
        //     srand(time(NULL)); // Seed the random number generator
        //     int slots_used = 0;
        //     int choice;

        //     struct surgeResult* head = readCSV(path);
        //     printf("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nSuccessfully read surges from %s\n", path);

        //     while (1) {
        //         printf("\n\nMenu:\n");
        //         printf("1. Cast spell\n");
        //         printf("2. Force surge\n");
        //         printf("3. Reset used slots\n");
        //         printf("4. Force surge by type\n");
        //         printf("0. Quit\n");
        //         printf("Enter your choice: ");
        //         scanf("%d", &choice);

        //         switch (choice) {
        //             case 0:
        //                 printf("Thank you for using my program!\n");
        //                 return EXIT_SUCCESS;
        //             case 1:
        //                 int level;
        //                 printf("What level spell slot are you using? ");
        //                 scanf("%d", &level);
        //                 slots_used += level;
        //                 slots_used = rollSurge(slots_used, head);
        //                 break;
        //             case 2:
        //                 triggerSurge(1,head);
        //                 break;
        //             case 3:
        //                 resetSlots(&slots_used);
        //                 break;
        //             case 4:
        //             	char type;
        //             	printf("What type of surge do you want to trigger? (1, 2, 3, or 4): ");
        //             	scanf(" %c", &type);
        //             	struct surgeResult* current = head;
        //             	int line_num = 1;
        //             	while (current != NULL) {
        //             	    if (current->Type == type) {
        //             	        char buffer[300];
        //             	        printf("Triggering surge of type %c...\n", type);
        //             	        printSurgeResult(line_num,*current, buffer);
        //             	        printf("%s\n", buffer);
        //             	        break; // Remove this if you want to print all surges of the specified type
        //             	    }
        //             	    current = current->next;
        //             	    line_num ++;
        //             	}
        //             	break;
        //             default:
        //                 printf("Invalid choice. Please try again.\n");
        //                 break;
        //         }
        //     }
        // }
    }
}
