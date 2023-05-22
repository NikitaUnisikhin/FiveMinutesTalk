// Подключение кнопки добавления к функции
document.querySelector('#AddQuestion1').addEventListener('click', function (ev) {
    newField(ev)
});

// Подключение изначального select к функции
document.querySelector('select').addEventListener('change', function (questionType) {
    changeComponents(questionType)
});

// Подключение кнопки закрытия к функции
document.querySelector(".close-button").addEventListener('click', removeParent);

let baseForm = document.getElementById("Form1");
let questions = [baseForm];

// Копируем изначальную форму
const copied = baseForm.cloneNode(true);

// Я предлагаю сделать глобальный id для вопросов, чтобы после удаления у нас не было совпадений id вопросов
let questionId = 1;
let numberQuestion = 1;

// У нас уже есть заранее склонированная форма, поэтому просто изменяем id в зависимости от questionId
function newField(ev) {
    let addQue = ev.currentTarget;
    let parent = addQue.parentNode;
    questionId++;
    numberQuestion++;
    let newCopied = copied.cloneNode(true);
    newCopied.id = "Form" + questionId;

    let arrayIndex = questionId - 1;
    let formControl = newCopied.getElementsByClassName('form-control')[0];
    formControl.name = `questions[${arrayIndex}].Text`;
    let formSelect = newCopied.getElementsByClassName('form-select')[0];
    formSelect.name = `questions[${arrayIndex}].Type`;

    let select = newCopied.querySelector("select");
    select.id = String(questionId);
    select.addEventListener('change', function (questionType) {
        changeComponents(questionType)
    });
    newCopied.querySelector("#Question1").id = "Question" + questionId;
    newCopied.querySelector("#Answer1").id = "Answer" + questionId;
    newCopied.querySelector(".bottom-question").querySelector(".right-part").querySelector(".close-button").addEventListener('click', removeParent);

    let addQuestion = newCopied.querySelector("#AddQuestion1")
    addQuestion.id = "AddQuestion" + questionId;
    addQuestion.addEventListener('click', function (ev) {
        newField(ev)
    });

    newCopied.querySelector(".hat-question").querySelector(".number-question").textContent = `${numberQuestion}.`;
    parent.after(newCopied);
}

function arrayRemove(arr, value) {

    return arr.filter(function (ele) {
        return ele.id !== value.id;
    });
}

function changeChildren(parent, value) {
    for (let i = Number(parent.id.slice(4)) + 1; i <= questionId; i++) {
        let current = document.getElementById(`Form${i}`);
        let currentNum = Number(current.querySelector("#hat-question").querySelector(".number-question").textContent[0]);
        current.querySelector("#hat-question").querySelector(".number-question").textContent = `${currentNum + value}.`;
    }
}

// Удаляет родителя...
function removeParent() {
    let revDiv = this.parentElement;
    arrayRemove(questions, revDiv);
    console.log(questions)
    changeChildren(revDiv, -1);
    numberQuestion -= 1;
    revDiv.remove();
}

// Функция в зависимости от выбранного типа будет менять варианты ответа под вопросом
function changeComponents(questionType) {
    // Получаем элемент на котором произошло событие
    let questType = questionType.currentTarget;
    let selectedValue = questType.value;
    let id = questType.id;

    // Здесь, зная id, мы получаем контейнер с вопросом и удаляем его
    let cont = document.getElementById("Answer" + id);
    cont.remove();

    // Тут же создаём новый
    let newDiv = document.createElement("div");
    newDiv.setAttribute("id", "Answer" + id);

    if (selectedValue === "0") {
        let text = document.createElement("input");
        text.setAttribute("placeholder", "Ответ");
        text.setAttribute("class", "text-question");
        text.setAttribute("id", "Text" + id);
        newDiv.appendChild(text);

    } else if (selectedValue === "1") {
        newDiv.innerText = "Код";

    } else if (selectedValue === "2") {
        // здесь создаем кнопку, которая добавляет новый label с radio кнопкой и вводом
        let addRadio = document.createElement("input");
        addRadio.setAttribute("value", "Добавить вариант ответа");
        addRadio.setAttribute("type", "button");
        addRadio.setAttribute("id", "AddRadio" + id);
        let col = 0;
        addRadio.addEventListener("click", function (e) {
            addNewRadio(e, id, col++)
        });
        addRadio.setAttribute("class", "add-variant");
        newDiv.appendChild(addRadio);
        addRadio.click();

    } else if (selectedValue === "3") {
        // здесь создаем кнопку, которая добавляет новый label с checkbox кнопкой и вводом
        let addCheckbox = document.createElement("input");
        addCheckbox.setAttribute("value", "Добавить вариант ответа");
        addCheckbox.setAttribute("type", "button");
        addCheckbox.setAttribute("id", "AddСheckbox" + id);
        let col = 0;
        addCheckbox.addEventListener("click", function (e) {
            addNewCheckbox(e, id, col++)
        });

        addCheckbox.setAttribute("class", "add-checkbox");
        newDiv.appendChild(addCheckbox);
        addCheckbox.click();
    }
    let addQuest = document.getElementById("Question" + questType.id);
    addQuest.appendChild(newDiv);
}

// функция по добавлению новых label с ratio и вводом
function addNewRadio(e, id, col) {
    // получаем из события нажатия, на каком объекте это произошло
    let addRad = e.currentTarget;

    let label = document.createElement("label");
    label.setAttribute("id", "Label" + id + `-${col}`);
    label.setAttribute("class", "radio-label");

    let radio = document.createElement("input");
    radio.setAttribute("type", "radio");
    radio.setAttribute("name", "Radio" + id)
    radio.setAttribute("id", "Radio" + id + `-${col}`);

    let radioText = document.createElement("input");
    radioText.setAttribute("placeholder", "Текст");
    radioText.setAttribute("type", "text");
    radioText.setAttribute("id", "RadioText" + id + `-${col}`);

    label.appendChild(radio);
    label.appendChild(radioText);

    addRad.before(label);
}

// обработка взаимодействия с чекбоксом
let countCorrectAnswers = new Map();

function checkMark(checkboxId, questionIndex, answerIndex) {
    let checkbox = document.getElementById(checkboxId);
    if (checkbox.checked === true) {
        if (countCorrectAnswers[questionIndex] === undefined)
            countCorrectAnswers[questionIndex] = 0;
        countCorrectAnswers[questionIndex]++;
        checkbox.name = `questions[${questionIndex}].CorrectAnswers`
        checkbox.value = answerIndex;
    } else {
        countCorrectAnswers[questionIndex]--;
        checkbox.name = '';
    }
}

// функция по добавлению новых label с checkbox и вводом
function addNewCheckbox(e, id, col) {
    let addCheck = e.currentTarget;

    let label = document.createElement("label");
    label.setAttribute("id", "Label" + id + `-${col}`);
    label.setAttribute("class", "checkbox-label");

    let checkbox = document.createElement("input");
    checkbox.setAttribute("type", "checkbox");
    checkbox.setAttribute("name", "Checkbox" + id)
    checkbox.setAttribute("id", "Checkbox" + id + `-${col}`);
    checkbox.setAttribute("class", "checkbox")
    checkbox.onclick = () => {
        checkMark(checkbox.id, id - 1, col);
    };

    let checkboxText = document.createElement("input");
    checkboxText.setAttribute("placeholder", "Текст");
    checkboxText.setAttribute("type", "text");
    checkboxText.setAttribute("id", "CheckboxText" + id + `-${col}`);
    checkboxText.setAttribute("name", `questions[${id - 1}].AnswerOptions`);
    checkboxText.setAttribute("class", "checkbox-text");

    label.appendChild(checkbox);
    label.appendChild(checkboxText);

    addCheck.before(label);
}