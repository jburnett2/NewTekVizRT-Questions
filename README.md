# NewTekVizRT-Questions

Listed below are my notes and thoughts on the questions that were given. I was able to provide working solutions for questions 2 and 3, but I know my solution for question 1 is not correct, which I will detail a little later. In this write up I am going to discuss the questions in the order that I completed them, which is as follows:

##### 1. Rövarspråk string converter
##### 2. Finding consecutive sums of natural numbers
##### 3. Sorting the bill of materials

## Rövarspråk string converter

Quite unsurprisingly, this is the question that I found the most straightforward and was the first one that I created a solution for. My method of approach for each of these questions was to first draft out a short list of what needs to be done, step by step. I tried to do this for each solution to map out the general behavior that is desired before I even started thinking about coding. When doing this, I try to first plan out the most simple (typically brute force) solution I can. In the case of this question, my list of what needs to be done was quite short:

**What needs to be done**

* Take in an input string
* Examine each character in the string to see if it is a vowel
  * If it is, then simply return the vowel
  * If not, then return the character appended with ‘o’ and the current character
    * Must be case sensitive

From here, it is time to take the leap from “what needs to be done” to “how to do it”. This can involve writing pseudocode, but in this case I decided to just expand some upon my previous list as this solution did not seem very complex. Thinking a bit more in depth on my previous list, this is the new list of steps I came up with.

**How to do it**
* Build a list of vowels
  * Due to case sensitivity, it would look like this: [a, e, i, o, u, A, E, I, O, U]
* Take in an input string
* Using a for loop, examine each index
* Build a new string based off of the consonant/vowel rules described above
* Return string

This was enough of a basis for me to begin coding, but first it’s time to finally consider optimization. Once I have the general logic mapped out to this degree, it is pretty easy to tell what the time complexity will be. My solution above runs at O(N) time, which while probably not as efficient as it could be, is enough for it to get the job done. I considered the possibility of attempting to use regex instead and see if I could lower the time complexity, but wanted to first create my solution before worrying about making it as optimized as possible.

Finally, I had the general behavior at each step mapped out and all that was left was the implementation. I followed along the logic that I outlined above, and was able to create a working solution with no issues.


## Finding consecutive sums of natural numbers

I wanted to lead with the previous question because it was a great example of things going exactly as I planned. That was definitely not the case with these next two questions. For both of these questions, I spent a long time attempting to come up with strategies for developing a solution, beginning to lay out pseudocode, but then realizing my logic was flawed and had to start over with a different approach. 

While doing this process for both remaining questions, I found the 3rd question more approachable than the 2nd (for reasons I will describe in its section), so I focused on developing a solution to the 3rd question. That being said, I was still struggling quite a bit to understand it, so I again tried to lay out the most simple, brute force solution I could, which looked like this:

**What needs to be done**

* Take an input from the user
  * Confirm that it is a natural number first
* Check all possible consecutive sums, starting at 1
* Start at 1 and repeatedly add consecutive numbers until the sum is equal to or greater than the input number
  * If sum = input, this was a successful sum
  * If sum > input, this was unsuccessful
* In either result, the process will then start over at 2 and do the same thing.
* Continue this process until the starting number is greater than (input/2)
  * Could instead go until the starting number is equal to the input, but this saves a little bit of time because if you are adding two consecutive numbers and the first is ½ of the input value, then it is guaranteed that all sums after this point will fail
* At this point, there are no more valid sums left, so return the amount of valid sums found

It didn’t take me all too long to lay out this general logic, but it did take me quite awhile to figure out a way to implement it. I was attempting to use a for loop for a while but ran into many issues with this logic, so instead decided to try out recursion. With recursion in mind, I then needed to outline the general structure of the function and how it would call itself. When brainstorming recursive behavior, I realized that my previous list had everything I needed, I just had to arrange it properly. This is the way that I laid out the structure of the function.

**How to do it**

* BASE CASE - once starting number is more than half of the input, exit out of the function and return the number of sums
* SUCCESS - when the sum equals the input. After this we need to add 1 to the starting index and start again
* FAILURE- when the sum is greater than the input. After this we need to add 1 to the starting index and start again
* IN PROGRESS - the sum is less than the input, and the starting number is less than half of the input. In this case we need to add the next consecutive number and start again to check for a success/failure

This gave me a good idea of the function’s structure, but now I needed to come up with the arguments to the function - all of the values that would be saved when the function is called again. Going over the above logic, the arguments that I came up with were:

* Int start - this is the starting index. Begins at 1 and is incremented on a success/failure
* Int next - this is the next number to be added to the sum. When the function first runs, start is 1 and next is 2. Whenever the function does not report a success/failure, ‘next’ is incremented and the function runs again. After a success/failure, ‘next’ needs to be set to 1 greater than ‘start’
* Int goal - this is the input number that we are trying to find the sums of. Never changes.
* Int numSums - this is the return value, the number of valid consecutive sums that equal ‘goal’
* Int sum - this is the running sum that is being checked against goal for success/failure. Starts as the same value as the starting index, and has ‘next’ added to it every time the function runs and does not report a success/failure

At this point, I finally had a pretty good understanding of the structure of the function that I wanted, as well as all the arguments required for it. From everything that I had here (and with my knowledge from my previous failed attempts) I was able to code up a working solution without too much additional trouble. I did run into an issue where everytime I was restarting my function after a success or failure, I was initializing ‘sum’ to 0, rather than to be equal to ‘start’. This caused my program to skip adding the starting number, and begin the sum with the first value of ‘next’ instead. However, thanks to some handy PrintLines I was able to resolve this fairly quickly.

## Sorting the bill of materials

Let me open by saying, if this was a problem I was given at work, I would have definitely sought help from another team member. There were many, many times with this question that I was struggling in very unproductive ways that really made it feel like I was banging my head against a wall. Before even being able to lay out any logic, I had a really hard time wrapping my head around the rules given and how they should behave - the rule “In case of nested children the smallest child must be under its closest parent” gave me a lot of trouble. I was having a very hard time understanding why the example was behaving the way described, and wasted a lot of time creating logic flows that did not work.

Finally, the moment when I started to make some progress was when I decided to draw out the data as a tree. I figured that if these nodes are being arranged by parent/children, then really what I was looking at was a non-binary tree. And sure enough, once I drew out the output, I realized that the sorted output was a pre-order traversal of this non-binary tree. 

So now this became an issue of how to do to a pre-order traversal of a non-binary tree that was organized off of parents, with nodes having no reference to their children. I was not sure if I was allowed to create a node class that stored its children (this is a question I should have asked), so I instead tried to use a node structure that only had the fields in the example output - name, ID, parentID, newID, and newHeaderID.

And just like that, I was back to banging my head against the wall. If I could go back and do things again, I would definitely try to use a node structure that stores its children - attempting to structure things how I did led to a lot of grief and confusion that didn’t really help me find a solution in any meaningful way. I assume the easiest answer probably involves recursion, seeing as ‘recursive sorting’ is in the name of the question, but I had a very hard time trying to understand what exactly the recursive behavior would be for this function.

In the end, after a few failed logic flows, I decided to focus my efforts on attempting to implement a solution that would use a for loop to go through the collection, and use what basically amounts to a very janky BubbleSort to determine the NewIDs of each node. The general flow for this process is as follows:

* For each object in the dataset, do the following
* Check to see if the currentNode has a parent
  * If not, set the NewID to the current index (+1 to account for 0 indexing)
* If the currentNode does have a parent, then find both the parent (‘parent’) and the node currently below the parent (‘belowParent’)
* Also update the currentNode’s NewHeaderID to the parent’s NewID now so that it does not have to be done in all future branching if statements
* Now we have to run a series of comparisons on currentNode and belowParent to determine whether the currentNode should be placed directly under its parent, or instead underneath belowParent
  * First check to see if currentNode == belowParent. If true, then both variables are referring to the same node, and it is already in the correct place
    * Set the NewID to the current index (every time I do this I’m adding +1 for 0 indexing, but I won’t say that every time)
  * If the nodes are not equal, then we check to see if their parentIDs are equal. 
    * If true, the nodes are siblings and the one with the smallest ID should be placed on top
    * If currentNode has a smaller ID, it takes belowParent’s spot and belowParent’s newID is adjusted accordingly
    * If not, then currentNode goes below belowParent
  * If the nodes are not siblings, then the one with a larger parentID should go on top. This causes children to be nested, rather than clustering all siblings together
    * If currentNode has a larger parentID, it takes belowParent’s spot and belowParent’s newID is adjusted accordingly
    * If not, then currentNode goes below belowParent

This is the logic that I followed to implement my non-functional solution to the first question. I feel like some of the code that I have made is salvageable, as some of the data points are being sorted correctly. However, it seems to be facing logic errors in logic for comparisons between siblings as well as nodes with parentIDs, and I am quite honestly not sure where these issues are stemming from. I also repeatedly got the feeling throughout this project that I was massively overcomplicating this issue, especially since I am hardly using the tree structure of this data at all. Whereas both of my previous solutions were fairly short and not too complex, this solution turned into a bloated mess of logic that became a nightmare to debug, even with my feeble attempts at commenting.

As I said before, the biggest thing I would have done differently is ask for help. I spent a long time frustrating myself and falling into unproductive rabbit-holes which led to me having a very hard time understanding my own logic.
