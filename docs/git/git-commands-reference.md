# Git Commands Reference

## Clean Old Branches

### Fetch and prune remote-tracking references

```bash
git fetch -p
git remote prune origin
```

### Delete ALL local branches whose remote is gone

```bash
git branch -vv | grep ': gone]' | awk '{print $1}' | xargs git branch -d
```

