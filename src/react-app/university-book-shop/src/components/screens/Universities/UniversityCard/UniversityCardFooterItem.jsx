// @ts-nocheck
import React from 'react';

import OkLogoItem from '../../../../Assets/OkLogoItem';

import styles from './UniversityCardFooterItem.module.css';

const UniversityCardFooterItem = ({ label, value }) => {
    return (
        <li>
            <OkLogoItem className={styles.okLogo} />
            {label} {value}
        </li>
    );
};

export default React.memo(UniversityCardFooterItem);
