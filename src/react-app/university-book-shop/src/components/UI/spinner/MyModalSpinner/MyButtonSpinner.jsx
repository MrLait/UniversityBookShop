// @ts-nocheck
import React from 'react';

import styles from './MyButtonSpinner.module.css';

const MyButtonSpinner = ({ isPending, buttonStyle }) => {
    const rootStyles = [styles.loading];
    if (isPending) {
        rootStyles.push(styles.loadingActive);
        if (buttonStyle === 'Black') {
            rootStyles.push(styles.loadingBlack);
        }
        else {
            rootStyles.push(styles.loadingWhite);
        }
    }

    return (
        <>
            {isPending && (
                <div className={rootStyles.join(' ')}>
                    <div className={
                        buttonStyle === 'Black'
                            ?
                            styles.loadingBlackSpinner
                            :
                            styles.loadingWhiteSpinner
                    }>
                    </div>
                </div>
            )}
        </>
    );
};

export default MyButtonSpinner;
