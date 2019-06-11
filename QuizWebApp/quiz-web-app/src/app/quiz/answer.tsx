import * as React from 'react';

type Props = {
    answer: {
        text: string,
        isCorrect: boolean
    },
    isSubmitted?: boolean,
    isSelected: boolean,
    onSelect: Function
};

export default class App extends React.Component<Props, {}> {
    public render() {
        const selectedClassName = !this.props.isSubmitted &&
            (this.props.isSelected
                ? 'quiz-answer__selected'
                : 'quiz-answer__not-selected');

        const correctClassName = this.props.isSubmitted && this.props.isSelected &&
            (this.props.answer.isCorrect
                ? 'quiz-answer__correct'
                : 'quiz-answer__wrong');

        const className = `quiz-answer ${selectedClassName} ${correctClassName}`;

        return (
            <div
                className={className}
                onClick={() => {
                    !this.props.isSubmitted &&
                        (this.props.isSelected
                            ? this.props.onSelect('')
                            : this.props.onSelect(this.props.answer.text));
                }}>
                {this.props.answer.text}
            </div>
        );
    }
}
                  