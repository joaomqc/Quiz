import * as React from 'react';

import Question from 'app/quiz/question';

type Props = {
    quiz: {
        name: string,
        questions: {
            text: string,
            answers: {
                text: string,
                isCorrect: boolean
            }[]
        }[]
    }
}

type State = {
    currentQuestion: number,
    selectedAnswers: string[],
    isSubmitted: boolean
}

export default class Quiz extends React.Component<Props, State> {

    constructor(props: any){
        super(props);

        this.state = {
            currentQuestion: 0,
            selectedAnswers: [],
            isSubmitted: false
        };
    }

    public render() {
        const numberOfQuestions = this.props.quiz.questions.length;

        return (
            <div className="quiz-wrapper">
                <div className="quiz-title">
                    {this.props.quiz.name}
                </div>
                <Question
                    question={this.props.quiz.questions[this.state.currentQuestion]}
                    selectedAnswer={this.state.selectedAnswers[this.state.currentQuestion]}
                    isSubmitted={this.state.isSubmitted}
                    onSelectAnswer={(answer: string)=>{
                        const answers = [...this.state.selectedAnswers];
                        answers[this.state.currentQuestion] = answer;
                        this.setState({selectedAnswers: answers})
                    }} />
                <div className="quiz-bottom-wrapper">
                    <button className="btn btn-primary"
                        onClick={() => this.setState({currentQuestion: this.state.currentQuestion-1})}
                        disabled={this.state.currentQuestion === 0}>
                            Previous
                    </button>
                    <div>
                        {`${this.state.currentQuestion+1}/${numberOfQuestions}`}
                    </div>
                    <button
                        className="btn btn-primary"
                        onClick={() => this.state.currentQuestion < numberOfQuestions-1
                            ? this.setState({currentQuestion: this.state.currentQuestion+1})
                            : this.setState({isSubmitted: true})} >
                            {this.state.currentQuestion < numberOfQuestions-1
                                ? 'Next'
                                : 'Submit'}
                    </button>
                </div>
            </div>
        );
    }
}
