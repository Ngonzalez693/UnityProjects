using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGameObj = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGameObj.GetComponent<Unit>();
        playerUnit.animator = playerGameObj.GetComponentInChildren<Animator>();

        GameObject enemyGameObj = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGameObj.GetComponent<Unit>();
        enemyUnit.animator = enemyGameObj.GetComponentInChildren<Animator>();

        dialogueText.text = "A wild " + enemyUnit.unitName + " Appeared!";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        dialogueText.text = "Attacking...";
        playerUnit.animator.SetTrigger("playerAttack");
        enemyUnit.animator.SetTrigger("enemyHurt");

        yield return new WaitForSeconds(1f);

        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        enemyHUD.SetHP(enemyUnit.currentHP);

        if (isDead)
        {
            state = BattleState.WON;
            enemyUnit.animator.SetBool("isDead", true);

            yield return new WaitForSeconds(enemyUnit.animator.GetCurrentAnimatorStateInfo(0).length);
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;

            yield return new WaitForSeconds(1.5f);
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + " is attacking you";
        enemyUnit.animator.SetTrigger("enemyAttack");
        playerUnit.animator.SetTrigger("hurt");

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.LOST;
            playerUnit.animator.SetBool("isDead", true);

            yield return new WaitForSeconds(playerUnit.animator.GetCurrentAnimatorStateInfo(0).length);
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "You won the battle!";
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You lost";
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an action:";
    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(5);
        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "Healing...";

        state = BattleState.ENEMYTURN;

        yield return new WaitForSeconds(2f);
        StartCoroutine(EnemyTurn());
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }
}
