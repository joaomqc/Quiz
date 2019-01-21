import * as React from 'react';

import NavBar from 'app/navbar';
import Quiz from 'app/quiz/quiz';

export default class App extends React.Component {
    public render() {
        const quiz = {
            name: 'Literature',
            questions: [
                {
                    answers: [
                        {
                            isCorrect: false,
                            text: 'Pride and Prejudice by Jane Austen'
                        },
                        {
                            isCorrect: true,
                            text: 'A Tale of Two Cities by Charles Dickens'
                        },
                        {
                            isCorrect: false,
                            text: 'Middlemarch by George Eliot'
                        },
                        {
                            isCorrect: false,
                            text: 'Great Expectations by Charles Dickens'
                        }
                    ],
                    text: '"It was the best of times, it was the worst of times..." begins which classic novel?'
                },
                {
                    answers: [
                        {
                            isCorrect: false,
                            text: 'The Russian Revolution'
                        },
                        {
                            isCorrect: false,
                            text: 'The American Revolution'
                        },
                        {
                            isCorrect: true,
                            text: 'The French Revolution'
                        },
                        {
                            isCorrect: true,
                            text: 'The Chinese Revolution'
                        }
                    ],
                    text: 'Which historical event does Charles Dickens\'s novel A Tale of Two Cities concern?'
                }
            ]
        };
    
        return (
            <div className="app">
                <NavBar />
                <Quiz quiz={quiz} />
            </div>
        );
    }
}
