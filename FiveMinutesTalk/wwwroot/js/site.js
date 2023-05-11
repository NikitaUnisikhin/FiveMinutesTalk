// Подключение кнопки добавления к функции
document.querySelector('#AddQuestion1').addEventListener('click', function(ev) {
    newField(ev)
});

// Подключение изначального select к функции
document.querySelector('select').addEventListener('change', function(questionType) {
    changeComponents(questionType)
});

// Подключение кнопки закрытия к функции
document.querySelector(".close-button").addEventListener('click', removeParent);

let baseForm = document.getElementById("Form1");

// Копируем изначальную форму
const copied = baseForm.cloneNode(true);

// Я предлагаю сделать глобальный id для вопросов, чтобы после удаления у нас не было совпадений id вопросов
let questionId = 1;

// У нас уже есть заранее склонированная форма, поэтому просто изменяем id в зависимости от questionId
function newField(ev) {
    let addQue = ev.currentTarget;
    let parent = addQue.parentNode;
    console.log(parent);
    questionId++;
    let newCopied = copied.cloneNode(true);
    newCopied.id = "Form" + questionId;
    
    let select = newCopied.querySelector("select");
    select.id = String(questionId);
    select.addEventListener('change', function(questionType) {
        changeComponents(questionType)
    });
    newCopied.querySelector("#Question1").id = "Question" + questionId;
    newCopied.querySelector("#Answer1").id = "Answer" + questionId;
    newCopied.querySelector(".close-button").addEventListener('click', removeParent);
    
    let addQuestion = newCopied.querySelector("#AddQuestion1")
    addQuestion.id = "AddQuestion" + questionId;
    addQuestion.addEventListener('click', function(ev) {
        newField(ev)
    });
    
    parent.after(newCopied);
}

// Удаляет родителя...
function removeParent(){
    let revDiv = this.parentElement;
    revDiv.remove();
}

// Функция в зависимости от выбранного типа будет менять варианты ответа под вопросом
function changeComponents(questionType){
    // Получаем элемент на котором произошло событие
    let questType = questionType.currentTarget;
    let selectedValue = questType.value;
    
    // Здесь, зная id, мы получаем контейнер с вопросом и удаляем его
    let cont = document.getElementById("Answer" + questType.id);
    cont.remove();
    
    // Тут же создаём новый
    let newDiv = document.createElement("div");
    newDiv.setAttribute("id", "Answer" + questType.id);
    
    if (selectedValue === "0"){
        newDiv.innerText = "Текст";
        
    } else if (selectedValue === "1"){
        newDiv.innerText = "Код";
        
    } else if (selectedValue === "2"){
        // здесь создаем кнопку, которая добавляет новый label с radio кнопкой и вводом
        let addRadio = document.createElement("input");
        addRadio.setAttribute("value", "Добавить вариант ответа");
        addRadio.setAttribute("type", "button");
        addRadio.setAttribute("id", "AddRadio" + questType.id);
        addRadio.addEventListener("click", function(e) {
            addNewRadio(e)
        });
        newDiv.appendChild(addRadio);
        
    } else if (selectedValue === "3"){
        // здесь создаем кнопку, которая добавляет новый label с checkbox кнопкой и вводом
        let addCheckbox = document.createElement("input");
        addCheckbox.setAttribute("value", "Добавить вариант ответа");
        addCheckbox.setAttribute("type", "button");
        addCheckbox.setAttribute("id", "AddСheckbox" + questType.id);
        addCheckbox.addEventListener("click", function(e) {
            addNewCheckbox(e)
        });
        newDiv.appendChild(addCheckbox);
    }
    let addQuest = document.getElementById("AddQuestion" + questType.id);
    addQuest.before(newDiv);
}

// функция по добавлению новых label с ratio и вводом
function addNewRadio(e){
    // получаем из события нажатия, на каком объекте это произошло
    let addRad = e.currentTarget;
    
    let label = document.createElement("label");
    label.setAttribute("id", addRad.id);
    label.setAttribute("class", "radio-label");
    
    let radio = document.createElement("input");
    radio.setAttribute("type", "radio");
    radio.setAttribute("name", addRad.id)
    radio.setAttribute("id", addRad.id);
    
    let radioText = document.createElement("input");
    radioText.setAttribute("placeholder", "Напишите вариант ответа");
    radioText.setAttribute("type", "text");
    radioText.setAttribute("id", addRad.id);
    
    label.appendChild(radio);
    label.appendChild(radioText);
    
    addRad.before(label);
}

// функция по добавлению новых label с checkbox и вводом
function addNewCheckbox(e){
    let addCheck = e.currentTarget;

    let label = document.createElement("label");
    label.setAttribute("id", addCheck.id);
    label.setAttribute("class", "checkbox-label");

    let checkbox = document.createElement("input");
    checkbox.setAttribute("type", "checkbox");
    checkbox.setAttribute("name", addCheck.id)
    checkbox.setAttribute("id", addCheck.id);

    let checkboxText = document.createElement("input");
    checkboxText.setAttribute("placeholder", "Напишите вариант ответа");
    checkboxText.setAttribute("type", "text");
    checkboxText.setAttribute("id", addCheck.id);

    label.appendChild(checkbox);
    label.appendChild(checkboxText);

    addCheck.before(label);
}