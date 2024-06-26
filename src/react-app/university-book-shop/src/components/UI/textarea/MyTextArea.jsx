// @ts-nocheck
import React, { useState, useEffect } from 'react';

import styles from './MyTextArea.module.css';

const MyTextArea = ({ error, isOpen, ...props }) => {
    const [textareaHeight, setTextareaHeight] = useState('var(--min-height-input)');

    useEffect(() => {
        if (!isOpen) {
            setTextareaHeight('var(--min-height-input)');
        }
    }, [isOpen]);

    const handleInput = (e) => {
        const target = e.target;
        target.style.height = 'auto';
        target.style.height = `${Math.min(target.scrollHeight, parseInt(getComputedStyle(target).maxHeight, 10))}px`;
        setTextareaHeight(target.style.height);
    };

    var rootStyles = [styles.textInput];
    if (error) {
        rootStyles.push(styles.borderColorError);
    }
    return (
        <>
            <textarea
                className={rootStyles.join(' ')}
                style={{ height: textareaHeight }}
                onInput={handleInput}
                {...props}
            />
            {error && <div className={styles.message}>{error}</div>}
        </>
    );
};

export default MyTextArea;