function Save() 
{
    let bookList = document.getElementById("bookList");
    let fname = document.getElementById("authorFirstName").value;
    let lname = document.getElementById("authorLastName").value;
    let title = document.getElementById("bookTitle").value;
    let publisYear = document.getElementById("publishYear").value;
    
    
    let entry = document.createElement('li');
    entry.appendChild(document.createTextNode("Author: "+fname));
    entry.appendChild(document.createTextNode(" ")); 
    entry.appendChild(document.createTextNode(lname));
    entry.appendChild(document.createElement('br'));
    entry.appendChild(document.createTextNode("Title: "+title));
    entry.appendChild(document.createElement('br'));
    entry.appendChild(document.createTextNode("Publish year: "+publisYear));
    entry.appendChild(document.createElement('br'));   
    entry.appendChild(document.createElement('br'));  

    bookList.appendChild(entry);


}

var changedText = document.getElementById('visibility');
let bookList = document.getElementById("bookList");
function listQ(){
    var e = document.getElementById("visibility");
    if(e.selectedIndex == 1)
    {
        bookList.style.visibility = "hidden" 
    }
    else if (e.selectedIndex == 2) 
    {
        bookList.style.visibility = "visible"
    }
  }
  document.getElementById("visibility").addEventListener("change",listQ);