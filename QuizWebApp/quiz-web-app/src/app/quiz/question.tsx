import * as React from 'react';

import Answer from 'app/quiz/answer';

type Props = {
    question: {
        text: string,
        answers: {
                text: string,
                isCorrect: boolean
        }[]
    },
    selectedAnswer: string,
    isSubmitted: boolean,
    onSelectAnswer: Function
};

export default class Question extends React.Component <Props> {

    constructor(props: Props){
        super(props);

        this.state = {
            selectedAnswer: ''
        }
    }

    public render() {
        return (
            <div className="quiz-question-wrapper">
                <div className="quiz-question">
                    {this.props.question.text}
                </div>
                <div className="quiz-answers-wrapper">
                    {this.props.question.answers.map(answer => (
                        <Answer
                            key={answer.text}
                            answer={answer}
                            isSelected={this.props.selectedAnswer === answer.text}
                            isSubmitted={this.props.isSubmitted}
                            onSelect={this.props.onSelectAnswer} />
                    ))}
                </div>
            </div>
        );
    }
}
